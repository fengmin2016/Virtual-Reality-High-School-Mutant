using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basketball_shoot : MonoBehaviour {
    private Animator _animator ;
    private AudioSource bballAud;

	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();
        _animator.SetBool("isHitted", false);
        bballAud = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        print("Something in collider.");
        if(other.tag =="basketball")
        {
            _animator.SetBool("isHitted", true);
            _animator.Play("netSwing");
            Debug.Log("bask2 play netswing");
            _animator.SetBool("isHitted", false);
            bballAud.Play();
        }
    }
}
