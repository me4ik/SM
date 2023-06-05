using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldLogic : NetworkBehaviour
{
    public float PushStrenth = 4f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().CmdPushBack(transform.right, PushStrenth);
        }
    }
}
