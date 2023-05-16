using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    public GameObject shield;

    private bool OnCD = false;
    private float CD = 2f;       //CD
    private float CDtimer = 0f;

    private float ShieldActive;
    public float ShieldTime = 1f;

    private void Start()
    {
        ShieldActive = ShieldTime;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && PlayerClasses.ClassID == 2 && !OnCD)
        {
            shield.SetActive(true);
            OnCD = true;
            CDtimer = CD;
        }

        if (OnCD)
        {
            ShieldActive -= Time.deltaTime;
            CDtimer -= Time.deltaTime;

            if (ShieldActive < 0f)
            {
                shield.SetActive(false);
            }
        }

        if (CDtimer < 0f)
        {
            CDtimer = 0f;
            OnCD = false;
            ShieldActive = ShieldTime;
        }



    }
}