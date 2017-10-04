using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RememberPlayer : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Respawn.Instance.lastTouched = this.gameObject;
        }
    }
}
