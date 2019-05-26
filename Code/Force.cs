using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour {

    public Rigidbody2D r;

	// Use this for initialization
	void Start () {
        r = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
       // r.AddForce(new Vector2(1, 0) * 1);
	}
}
