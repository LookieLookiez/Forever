using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    public static Respawn Instance;
    public GameObject player;
    public GameObject lastTouched;
    public float spawnOffset;

	// Use this for initialization
	void Start () {
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        var spawnPos = new Vector2(lastTouched.transform.position.x, lastTouched.transform.position.y + spawnOffset);
        player.transform.position = spawnPos;
    }
}
