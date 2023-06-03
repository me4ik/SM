using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLogic : NetworkBehaviour
{
    private float _ShootStrenth;
    private float ArrowDamage;

    public GameObject player;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        ArrowDamage = player.GetComponent<ArrowShoot>().ShootStrenth;
        Invoke("DestroyArr", 15f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obs"))
        {
            Destroy(gameObject);
        }

        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyHealth>().CmdgetDamage(Convert.ToInt32(ArrowDamage));
            Destroy(gameObject);
        }

    }


    void DestroyArr()
    {
        Destroy(gameObject);
    }
}
