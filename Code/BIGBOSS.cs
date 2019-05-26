using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BIGBOSS : MonoBehaviour {

    public GameObject[] targets;
    public GameObject target;
    private Transform targetpos;
    float boom;
    float dist;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Planet")
        {
            Destroy(collision.gameObject);
            gameObject.transform.localScale -= new Vector3(gameObject.transform.localScale.x/10, gameObject.transform.localScale.y/10);
            gameObject.GetComponent<Rigidbody2D>().mass -= 10f;
        }
    }

    // Use this for initialization
    void Start () {
        boom = 2.0f;
	}

    void Destroy()
    {
        CancelInvoke("Destroy");
        targets = GameObject.FindGameObjectsWithTag("Planet");
        foreach (GameObject obj in targets)
        {
            var dist1 = Vector3.Distance(obj.transform.position, transform.position);
            if (dist1 <= dist)
                Destroy(obj);
        }
        targets = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject obj in targets)
        {
            var dist1 = Vector3.Distance(obj.transform.position, transform.position);
            if (dist1 <= dist)
                Destroy(obj);
        }
        target.transform.localScale -= new Vector3(0.3f, 0.3f);
        target.GetComponent<Rigidbody2D>().mass -= 30f;
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update () {
        if (gameObject.GetComponent<Rigidbody2D>().mass < 1f)
            Destroy(gameObject);
        var maxVelocity = 2.0f;
        dist = Vector3.Distance(target.transform.position, transform.position);
        var maxdist = 5f;
        gameObject.GetComponent<Rigidbody2D>().velocity = (target.transform.position - transform.position).normalized * (float)(maxVelocity);
        if ( dist <= maxdist )
        {
            gameObject.transform.localScale += new Vector3(boom, boom);
            Invoke("Destroy", 0.1f);
        }
    }
}
