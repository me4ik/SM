using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int Hp = 100;
    private SpriteRenderer sr;
    Color col;

    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();  

        col.r = sr.color.r;
        col.g = sr.color.g;
        col.b = sr.color.b;
        col.a = sr.color.a;

        rb = GetComponent<Rigidbody2D>();   

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public int getDamage(int DmgRs)
    {
        Hp -= DmgRs;
        col.r -= 0.1f;
        sr.color = col;
        Debug.Log(Hp);
        return Hp;
    }

    public void PushBack(Vector2 direct, float pushStr)
    {
        rb.AddForce(direct * pushStr);
        Debug.Log("pushed Back " + direct);
    }
}
