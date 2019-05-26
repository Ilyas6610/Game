using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{

    //public GameObject Hole;
    public Rigidbody2D rb2, rb1;
    public CapsuleCollider2D r, r2;

    // Use this for initialization
    public GameObject target;
    //public Transform pos;
    public Count c;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Planet")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            //GameObject New = Instantiate(collision.gameObject);
            //New.transform.position = new Vector2(-18, Random.Range(-6.2f, 6.2f));
            //New.GetComponent<Gravity>().enabled = true;
            //New.GetComponent<CapsuleCollider2D>().enabled = true;
            //New.GetComponent<Force>().enabled = true;
            //rb2 = New.GetComponent<Rigidbody2D>();
        }
    }

    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        r = target.GetComponent<CapsuleCollider2D>();
        r2 = GetComponent<CapsuleCollider2D>();
        rb1 = target.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        var G = 6.67 * Mathf.Pow(10, -11);
        var destDist = Mathf.Max(r.size.x * rb1.transform.localScale.x / 2, r.size.y * rb1.transform.localScale.x / 2) + Mathf.Max(r2.size.x / 2, r2.size.y / 2) + 0.1f;
        var maxDist = 5.0 * rb1.transform.localScale.x;
        var maxVelocity = 5.0;
        var dist = Vector3.Distance(target.transform.position, transform.position);
        //rb2.velocity = (target.transform.position - transform.position).normalized;
        rb2.velocity = (target.transform.position - transform.position).normalized * (float)(maxVelocity);
        //if (dist <= destDist)
        //{
        //    Destroy(gameObject);
        //    target.transform.localScale -= new Vector3(0.1f, 0.1f);
        //    rb1.mass -= 10;
        //    /*GameObject New = Instantiate(gameObject);
        //    New.transform.position = new Vector2(-18, Random.Range(-6.2f, 6.2f));
        //    New.GetComponent<Gravity>().enabled = true;
        //    New.GetComponent<CapsuleCollider2D>().enabled = true;
        //    New.GetComponent<Force>().enabled = true;
        //    rb2 = New.GetComponent<Rigidbody2D>();*/
        //}
    }

}
