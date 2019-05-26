using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleControl : MonoBehaviour {

    public Rigidbody2D rb;
    public Rigidbody2D rb2;
    public GameObject Game, End;
    //private Count c;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            rb = GetComponent<Rigidbody2D>();
            rb.mass -= 10f;
            gameObject.transform.localScale -= new Vector3( 0.1f, 0.1f, 0.1f );
            //GameObject New = Instantiate(collision.gameObject);
            //New.transform.position = new Vector2(-18, Random.Range(-6.2f, 6.2f));
            //New.GetComponent<Gravity>().enabled = true;
            //New.GetComponent<CapsuleCollider2D>().enabled = true;
            //New.GetComponent<Force>().enabled = true;
            //rb2 = New.GetComponent<Rigidbody2D>();
        }
    }

    // Use this for initialization
    void Start ()
    {
        Vector2 start = new Vector2(0, 0);
        rb = GetComponent<Rigidbody2D>();
        rb.MovePosition(start);
        rb.gravityScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (rb.mass < 1 )
        {
            Destroy( gameObject );
            Game.SetActive(false);
            End.SetActive(true);
        }
        var x = 1000f;
        rb = GetComponent<Rigidbody2D>();
        float moveX = Input.mousePosition.x;
        float moveY = Input.mousePosition.y;
        Vector2 pos = new Vector2(moveX, moveY);
        //rb.MovePosition();
        rb.transform.position = Vector2.MoveTowards(rb.transform.position, Camera.main.ScreenToWorldPoint(pos), x / rb.mass * Time.deltaTime);
	}
}
