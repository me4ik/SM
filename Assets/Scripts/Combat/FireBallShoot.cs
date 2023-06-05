using Mirror;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class FireBallShoot : NetworkBehaviour
{
    private PlayerClasses clas;

    public GameObject fireball;
    public Transform firePoint;
    public float bulletSpeed = 50;

    private bool JustFired = false;
    public float FireCd = 1f;
    private float FireTimer = 0;

    //public Slider CDSlider;
    private void Start()
    {
        clas = GetComponent<PlayerClasses>();
    }

    void Update()
    {
        if (!isLocalPlayer) return;

        if (Input.GetKeyDown(KeyCode.Mouse0) && clas.ClassID == 1 && !JustFired)
        {
            FireTimer = FireCd;
            CmdShootFBall();
            JustFired = true;
            Debug.Log("Just Fired" + FireCd);
            //CDSlider.maxValue = FireCd;
        }

        if (JustFired)
        {
            FireTimer -= Time.deltaTime;
            //CDSlider.value = FireTimer;
        }
        if (FireTimer < 0)
        {
            JustFired = false;
            FireTimer = 0;
        }

    }

    [Command]
    private void CmdShootFBall()
    {        
        GameObject fblClone = Instantiate(fireball, firePoint.position, firePoint.rotation);
        NetworkServer.Spawn(fblClone);
        fblClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;
    }


}
