using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class FireBallShoot : MonoBehaviour
{
    public GameObject fireball;
    public Transform firePoint;
    public float bulletSpeed = 50;

    private bool JustFired = false;
    private float FireCd = 1f;
    private float FireTimer = 0;

    public Slider CDSlider;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && PlayerClasses.ClassID == 1 && !JustFired)
        {
            ShootFBall();
            JustFired = true;
            Debug.Log("Just Fired" + FireCd);
            CDSlider.maxValue = FireCd;
        }

        if (JustFired)
        {
            FireTimer -= Time.deltaTime;
            CDSlider.value = FireTimer;
        }
        if (FireTimer < 0)
        {
            JustFired = false;
            FireTimer = 0;
        }

    }

    private void ShootFBall()
    {
        FireTimer = FireCd;
        GameObject fblClone = Instantiate(fireball, firePoint.position, firePoint.rotation);
        fblClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;
    }


}
