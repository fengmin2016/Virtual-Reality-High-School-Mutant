using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShirtChange : MonoBehaviour {

    public Material[] ShirtChange;
    public Animator _animator;

    // Use this for initialization
    void Start () {
        _animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
       // if (Global.guard_hitCurr == 1) { }
	}
}
