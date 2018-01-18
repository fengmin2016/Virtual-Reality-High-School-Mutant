using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSparks : MonoBehaviour
{

    //public Transform sparks;
    public ParticleSystem sparks;
    private AudioSource lightAud;
   
    

    // Use this for initialization
    void Start()
    {
        ParticleSystem sparks = GetComponent<ParticleSystem>();
        //ParticleSystem.EmissionModule em = sparks.emission;
        //em.enabled = false;
        //sparks.enableEmission = false;
        lightAud = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Slime")
        {
            sparks.Play();
            lightAud.Play();
            //ParticleSystem.EmissionModule em = sparks.emission;
            //em.enabled = true;
        }
        if (other.tag == "Bullet")
        {
            sparks.Play();
            lightAud.Play();
            //ParticleSystem.EmissionModule em = sparks.emission;
            //em.enabled = true;
        }
    }
}