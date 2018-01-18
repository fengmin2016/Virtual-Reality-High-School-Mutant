using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Handler : MonoBehaviour {
    private Animator _animator = null;


	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();
        _animator.SetBool("isHit", false);
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "Slime")
        {
            _animator.SetBool("isHit", true);
            _animator.Play("doorBlow");
            Debug.Log("door opened");

        }
    }
    //void OnTriggerExit(Collider collider)
    //{
        //if (collider.tag == "Arm")
        //{
            //_animator.SetBool("isopen", false);
            //Debug.Log("door closed");

        //}
    //}
}
