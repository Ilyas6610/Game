using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour {

    public GameObject target, bullet;
    public Rigidbody2D targetRB, bulletRB, RB;
    public int bulletCount = 0;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Planet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            //GameObject New = Instantiate(collision.gameObject);
            //New.transform.position = new Vector2(-18, Random.Range(-6.2f, 6.2f));
            //New.GetComponent<Gravity>().enabled = true;
            //New.GetComponent<CapsuleCollider2D>().enabled = true;
            //New.GetComponent<Force>().enabled = true;
            //rb2 = New.GetComponent<Rigidbody2D>();
        }
        else if (collision.gameObject.tag == "Background")
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        targetRB = target.GetComponent<Rigidbody2D>();
        //bulletRB = bullet.GetComponent<Rigidbody2D>();
        RB = gameObject.GetComponent<Rigidbody2D>();
	}

    void Fire()
    {
        CancelInvoke("Fire");
        Vector3 dir = target.transform.position - transform.position;
        Vector3 pos = transform.TransformPoint((dir) / Mathf.Sqrt(Mathf.Pow(transform.position.x, 2) + Mathf.Pow(transform.position.y, 2)));
        GameObject New = Instantiate(bullet);
        New.transform.position = pos;
        bulletRB = New.GetComponent<Rigidbody2D>();
        New.GetComponent<SpriteRenderer>().enabled = true;
        New.GetComponent<BulletDestroy>().enabled = true;
        New.GetComponent<CapsuleCollider2D>().enabled = true;
        bulletRB.velocity = (target.transform.position - transform.position);
    }

     // Update is called once per frame
     void FixedUpdate () {
        var maxDist = 5.0;
        var maxVelocity = 5.0;
        var distance = Vector3.Distance(target.transform.position, transform.position);
        if( distance > maxDist )
            RB.velocity = (target.transform.position - transform.position).normalized * (float)(maxVelocity);
        else
        {
            RB.velocity = new Vector3 (0, 0);
            Invoke("Fire", 0.5f);
        }
    }
}
