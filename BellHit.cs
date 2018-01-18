using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellHit : MonoBehaviour {

    public AudioClip bellSound;
    private AudioSource bellAud;

	// Use this for initialization
	void Start ()
    {
        bellAud = GetComponent<AudioSource>();
	}

    void OnTriggerEnter(Collider other3)
    {

        if (other3.tag == "Bullet")
        {
            bellAud.clip = bellSound;
            bellAud.Play();
        }
    }
}
