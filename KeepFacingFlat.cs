using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepFacingFlat : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.rotation = Quaternion.LookRotation(Vector3.down, Camera.main.transform.position - this.transform.position);
	}
}
