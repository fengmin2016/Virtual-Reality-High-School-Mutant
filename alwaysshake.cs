using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alwaysshake : MonoBehaviour {
    private Animator _animator;

    // Use this for initialization
    void Start () {
        _animator = GetComponent<Animator>();

        _animator.SetBool("isShake", false);
        //_animator.SetBool("isAlwaysshake", false);
    }

    // Update is called once per frame
    void Update(){

    }
		
	

    void onTriggerEnter(Collider collider)
    {
        if (collider.tag == "Bullet")
        {

            _animator.SetBool("isShake", true);
            //_animator.SetBool("isAlwaysshake", true);

            _animator.Play("shake");
            //_animator.Play("test_awaysshake");
            Debug.Log("AlwaysShake");
        }
    }
}
