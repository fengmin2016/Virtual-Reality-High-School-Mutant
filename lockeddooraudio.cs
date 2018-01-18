using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockeddooraudio : MonoBehaviour
{

    public AudioClip DoorLocked;
    private AudioSource LockedAud;

    // Use this for initialization
    void Start()
    {

        LockedAud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Arm")
        {
            //if input of controller is grip
            LockedAud.clip = DoorLocked;
            LockedAud.Play();
            
        }
    }
}
