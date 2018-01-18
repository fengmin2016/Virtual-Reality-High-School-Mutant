using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreboardAudio : MonoBehaviour {


    private AudioSource scoreBoardAud;

    // Use this for initialization
    void Start()
    {
        scoreBoardAud = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            scoreBoardAud.Play();
        }
    }
}
