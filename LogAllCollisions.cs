using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogAllCollisions : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("WE HIT: " + collision.collider.name);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
