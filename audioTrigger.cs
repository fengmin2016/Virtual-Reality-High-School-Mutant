using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioTrigger : MonoBehaviour {

    public AudioClip sound;
    private AudioSource aud;
    private bool beenHere;

	// Use this for initialization
	void Start () {
        aud = GetComponent<AudioSource>();
        aud.clip = sound;
        beenHere = false;
        
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "LaserTip" && beenHere == false)
        {
            aud.Play();
            beenHere = true;
        }
    }
}
