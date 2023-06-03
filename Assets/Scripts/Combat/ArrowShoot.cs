using Mirror;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ArrowShoot : NetworkBehaviour
{
    public GameObject Arrow;
    public Transform ShootPoint;

    public float ShootStrenth = 1f;
    private bool IsCharging = false;
    private bool NeStrelyay = false;
    public float MaxCharge = 15f;

    private bool IsOnCD = false;
    private float CDtimer = 0f;   
    public float CD = 2f;

    //public Slider CDSlider;
    //public Slider ArrowSlider;


    private void Start()
    {
       // ArrowSlider.maxValue = MaxCharge;
    }

    void Update()
    {
        if (!isLocalPlayer) return;

        if (Input.GetKeyDown(KeyCode.Mouse0) && PlayerClasses.ClassID == 3 && !IsOnCD) 
        {
            Debug.Log("mouse is down");
            IsCharging = true;
            NeStrelyay = false;
            //CDSlider.maxValue = CD;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && PlayerClasses.ClassID == 3 && IsOnCD)
            NeStrelyay = true;

            if (IsCharging) 
        { 
            ShootStrenth += Time.deltaTime * 4.2f;
            //ArrowSlider.value = ShootStrenth;
        }


        if (Input.GetKeyUp(KeyCode.Mouse0) && PlayerClasses.ClassID == 3 && !IsOnCD && !NeStrelyay) 
        {
            IsCharging = false; 
            Debug.Log("Mouse is Up");

            if (ShootStrenth > MaxCharge) ShootStrenth = MaxCharge; 

            Shoot(ShootStrenth); 
            Debug.Log("Released an arrow " + ShootStrenth); 
           IsOnCD = true;
            //ArrowSlider.value = 0f;

        }


        if (IsOnCD)
        {
              CDtimer -= Time.deltaTime;
            //CDSlider.value = CDtimer;
        }
            
        if (CDtimer < 0)
        {
            ShootStrenth = 1f;
            IsOnCD = false;
            CDtimer = 0;
        }

    }

    private void Shoot(float sila)
    {
         CDtimer = CD;
        GameObject ArrowClone = Instantiate(Arrow, ShootPoint.position, ShootPoint.rotation);
        NetworkServer.Spawn(ArrowClone);
        ArrowClone.GetComponent<Rigidbody2D>().velocity = ShootPoint.right * sila;
    }
}
