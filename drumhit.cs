using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drumhit : MonoBehaviour {

    public AudioSource SoundSource;



	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "drumstick")
        {
            SoundSource.Play();
        }
    }
    

}
