using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hittest : MonoBehaviour {
    private Animator _animator ;

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
           // _animator.Play("doorBlow");
            _animator.Play("DoorBlow");
            Debug.Log("door opened");

        }
    }
}
