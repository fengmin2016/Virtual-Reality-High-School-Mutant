using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistractionHit : MonoBehaviour
{

    //public Material[] materialToChange;
    public Animator _animator;
    public AudioClip WhatWasThat;
    private AudioSource DistractionAudio;
    //Renderer gameObjectToChange;

    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("TurnLeft", false);
        DistractionAudio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other3)
    {

        if (other3.tag == "Bullet" || other3.tag == "Slime")
        {
            // gameObject.GetComponent<Renderer>().material = materialToChange[1];
            Global.balloonHit = true;
            print("gottosound");
            DistractionAudio.clip = WhatWasThat;
            DistractionAudio.Play();
            print("playedsound");
            //Destroy(other3.gameObject);
            //Destroy(gameObject);
        }

        /* if (other3.tag == "Slime")
        {
            // gameObject.GetComponent<Renderer>().material = materialToChange[1];

            //this.gameObject.GetComponent<Rigidbody>().useGravity = true;
            Global.balloonHitRight = true;
            //Destroy Gameobject
        } */


    }


}