using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    private float Scale;
    private int count;
    public Transform firepos;
    public GameObject planet;

	// Use this for initialization
	void Start () {
        count = 1;
        Scale = 1f;
		
	}
	
	// Update is called once per frame
	void Update () {
		if( Scale < transform.localScale.x)
        {
            Scale = transform.localScale.x;
            count++;
        }
        if( count != 0 && Input.GetKeyDown(KeyCode.Space))
        {
            count--;
            transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
            Scale = transform.localScale.x;
            GameObject New = Instantiate(planet);
            New.transform.position = firepos.transform.position;
            //New.GetComponent<Gravity>().enabled = true;
            New.GetComponent<CapsuleCollider2D>().enabled = true;
            New.GetComponent<Force>().enabled = true;
        }
	}
}
