using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FireBallLogic : MonoBehaviour
{
 
    public float speed = 3f;
    private Rigidbody2D rb;
    private GameObject fball;
    public int fbalDamage = 10;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fball = GetComponent<GameObject>();

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
            other.gameObject.GetComponent<EnemyHealth>().getDamage(fbalDamage);
            Destroy(gameObject);

        }

    }

}
