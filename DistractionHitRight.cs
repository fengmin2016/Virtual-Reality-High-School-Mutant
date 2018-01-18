using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistractionHitRight : MonoBehaviour
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
        _animator.SetBool("TurnRight", false);
        DistractionAudio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other3)
    {

        if (other3.tag == "Bullet" || other3.tag == "Slime")
        {
            // gameObject.GetComponent<Renderer>().material = materialToChange[1];
            Global.balloonHitRight = true;
            DistractionAudio.clip = WhatWasThat;
            DistractionAudio.Play();
            // _animator.SetBool("TurnRight", true);
            //Destroy(other3.gameObject);
            //Destroy(gameObject);
        }
    }

   

            /* if (other3.tag == "Slime")
            {
                // gameObject.GetComponent<Renderer>().material = materialToChange[1];

                //this.gameObject.GetComponent<Rigidbody>().useGravity = true;
                Global.balloonHitRight = true;
                //Destroy Gameobject
            } */


        }

