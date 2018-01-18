using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locker3 : MonoBehaviour
{
    public AudioClip lockerOpen;
    public AudioClip lockerClose;
    private AudioSource lockerAud;

    private Animator _animator = null;
    bool doorOpen = false;
    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("isopen", false);
        lockerAud = GetComponent<AudioSource>();
        //_animator.SetBool("isopen", false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Arm" && doorOpen == false)
        {
            //if input of controller is grip
            //play open animation
            _animator.SetBool("isopen", true);
            lockerAud.clip = lockerOpen;
            lockerAud.Play();
            _animator.Play("lockerdoor3_open");
            doorOpen = true;
        }
        else if (other.tag == "Arm" && doorOpen == true)
        {
            //if input of controller is grip
            //play close animation
            _animator.SetBool("isopen", false);
            lockerAud.clip = lockerClose;
            lockerAud.Play();
            _animator.Play("lockerdoor3_close");
            doorOpen = false;
        }

    }
}
