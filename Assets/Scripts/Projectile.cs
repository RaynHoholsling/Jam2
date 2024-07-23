using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float velocity;
    public int damage;

    private void Start()
    {
        //ExplosionDamage();
    }

    private void Update()
    {
        if ((transform.position.x >= 500 || transform.position.x <= -500) || (transform.position.y >= 500 || transform.position.y <= -500))
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.right * velocity * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.collider != null) && (collision.collider.CompareTag("Player") == false))
        {
            if (collision.gameObject.CompareTag("Destructable"))
            {
                //ExplosionDamage();
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }
    }
    //void ExplosionDamage()
    //{
    //    Collider2D[] collider2D = Physics2D.OverlapCircleAll(transform.position, 1);
    //    if (collider2D.Length > 0)
    //    {
    //        foreach (Collider2D col in collider2D)
    //        {
    //            if (col.tag == "Destructable")
    //            {
    //                Destroy(col.gameObject);
    //            }
    //        }
    //    }
    //}
}
