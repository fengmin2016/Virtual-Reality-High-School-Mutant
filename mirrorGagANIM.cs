using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorGagANIM : MonoBehaviour {

    private Animator anim;
    private bool yes;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        yes = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (mirrorGlobal.beenThere == true && yes == false)
        {
            anim.SetBool("gagON", true);
            anim.Play("mirrorAnim");
            anim.SetBool("gagON", false);
            yes = true;
        }
    }
}
