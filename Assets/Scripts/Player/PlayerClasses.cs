using Mirror;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerClasses : NetworkBehaviour
{
    public static int ClassID = 1;

    public GameObject Bow;
    public GameObject Slider;

    public void SwitchClass1()
    {
        ClassID = 1;
        Debug.Log(ClassID);
        Bow.SetActive(false);
        Slider.SetActive(false);
    }

    public void SwitchClass2()
    {
        ClassID = 2;
        Debug.Log(ClassID);
        Bow.SetActive(false);
        Slider.SetActive(false);
    }

    public void SwitchClass3()
    {
        Bow.SetActive(true);
        Slider.SetActive(true);
        ClassID = 3;
        Debug.Log(ClassID);
    }

    void Update()
    {
        if (!isLocalPlayer) return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchClass1();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchClass2();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchClass3();
        }

    }


}
