using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceBack : MonoBehaviour
{

    public Rigidbody2D r, rb2;
    //private Count c;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Planet")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            GameObject New = Instantiate(collision.gameObject);
            New.transform.position = new Vector2(-18, Random.Range(-6.2f, 6.2f));
            New.GetComponent<Gravity>().enabled = true;
            New.GetComponent<CapsuleCollider2D>().enabled = true;
            New.GetComponent<Force>().enabled = true;
            rb2 = New.GetComponent<Rigidbody2D>();
        }
        else if (collision.gameObject.tag == "Background")
            Destroy(gameObject);
    }

    // Use this for initialization
    void Start()
    {
        //r = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //r.AddForce(new Vector2(-1, 0) * 100);
        
    }
}