using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PASystemPlay : MonoBehaviour {

    private AudioSource paAud;

	// Use this for initialization
	void Start () {

        paAud = GetComponent<AudioSource>();

		if(mirrorGlobal.beenThere == false)
        {
            paAud.Play();
        }
        else
        {
            return;
        }
	}

}
