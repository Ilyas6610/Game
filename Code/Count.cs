using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count : MonoBehaviour {

    public int count = 2, count2 = 1;
    public GameObject[] obj;
    public Transform pos;
    public GameObject target, target2, target3;

    // Use this for initialization
    void Start () {
        obj = GameObject.FindGameObjectsWithTag("Planet");
    }
	
	// Update is called once per frame
	void Update ()
    {
        obj = GameObject.FindGameObjectsWithTag("Planet");
        if ( obj.Length - 1 == 0 )
        {
            for (int i = 0; i < count; i++)
            {
                var LRUD = Mathf.Floor( Random.Range( 1f, 4.99999f) ) ;
                GameObject New = Instantiate(target.gameObject);
                if( LRUD == 1 )
                    New.transform.position = new Vector2(-18.22f, Random.Range(-7.5f, 7.5f));
                else if( LRUD == 2)
                    New.transform.position = new Vector2(Random.Range(-18.22f, 18.22f), 7.5f);
                else if (LRUD == 3)
                    New.transform.position = new Vector2(18.22f, Random.Range(-7.5f, 7.5f));
                else if (LRUD == 4)
                    New.transform.position = new Vector2(Random.Range(-18.22f, 18.22f), -7.5f);
                New.GetComponent<SpriteRenderer>().enabled = true;
                New.GetComponent<Gravity>().enabled = true;
                New.GetComponent<CapsuleCollider2D>().enabled = true;
                New.GetComponent<Force>().enabled = true;
                New.GetComponent<Count>().enabled = false;
            }
            count++;
        }

        obj = GameObject.FindGameObjectsWithTag("Enemy");
        if (obj.Length - 1 == 0)
        {
            for (int i = 0; i < count2; i++)
            {
                GameObject New;
                var enemyType = Mathf.Floor(Random.Range(1f, 2.99999f));
                var LRUD = Mathf.Floor(Random.Range(1f, 4.99999f));
                if (enemyType == 1)
                {
                    New = Instantiate(target2.gameObject);
                    New.GetComponent<SpriteRenderer>().enabled = true;
                    New.GetComponent<Enemy1>().enabled = true;
                    New.GetComponent<CapsuleCollider2D>().enabled = true;
                }
                else
                {
                    New = Instantiate(target3.gameObject);
                    New.GetComponent<SpriteRenderer>().enabled = true;
                    New.GetComponent<Enemy2>().enabled = true;
                    New.GetComponent<CapsuleCollider2D>().enabled = true;
                }
                if (LRUD == 1)
                    New.transform.position = new Vector2(-18.22f, Random.Range(-7.5f, 7.5f));
                else if (LRUD == 2)
                    New.transform.position = new Vector2(Random.Range(-18.22f, 18.22f), 7.5f);
                else if (LRUD == 3)
                    New.transform.position = new Vector2(18.22f, Random.Range(-7.5f, 7.5f));
                else if (LRUD == 4)
                    New.transform.position = new Vector2(Random.Range(-18.22f, 18.22f), -7.5f);
            }
            count2++;
        }
    }
}
