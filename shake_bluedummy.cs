using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shake_bluedummy : MonoBehaviour {

    private Animator _animator;
    private AudioSource tdAud;

    public AudioClip shakeSoundTD;
    public int count = 0;

    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.enabled = false;
        tdAud = GetComponent<AudioSource>();
        //_animator.SetBool("isShake", false);
    }
    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "Bullet")
        {
            _animator.enabled = true;
            _animator.Play("dummy_blue");
            tdAud.clip = shakeSoundTD;
            tdAud.Play();
            count = count + 1;
        }




        /* if (collider.tag == "Bullet")
         {
             _animator.enabled = true;
             if (count == 0)

                 _animator.Play("shake");
             else if (count == 1)

                 _animator.Play("shake2");
             else if (count == 2)
                 _animator.Play("shake3");

             Debug.Log("TackleShake");

          count = count + 1;*/


        //else
        //{
        // _animator.Play("shake");
        // count = count + 1;
        // }


    }
}
