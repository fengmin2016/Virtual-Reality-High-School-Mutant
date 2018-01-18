using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockerdoor3_shake : MonoBehaviour
{
    private Animator _animator;

    public int count = 0;

    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.enabled = false;
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
            _animator.Play("lockerdoor3_shake");    
            count = count + 1;
        }
    }
}
