using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitZonich : NetworkBehaviour
{

    public int damageN = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealth>().CmdgetDamage(damageN);
        }
    }

}
    