using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoThroughPlatform : MonoBehaviour {

    public Collider2D floorCollider;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Trying to go through!");
            floorCollider.GetComponent<EdgeCollider2D>().enabled = false;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            floorCollider.GetComponent<EdgeCollider2D>().enabled = true;
        }
    }

}
