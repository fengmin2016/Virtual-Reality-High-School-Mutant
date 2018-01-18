using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_shake : MonoBehaviour {

    private Animator _animator;
   // public int count = 0;

    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("isShakee", false);

    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Bullet")
        {
            _animator.SetBool("isShakee", true);

            //if (count = count+1)


            // _animator.Play("doorBlow");
            _animator.Play("test_shake");
            Debug.Log("cubeshake");
        }
    }
}
