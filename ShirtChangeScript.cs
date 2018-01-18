using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShirtChangeScript : MonoBehaviour {

    public Material[] materialToChange;
    public Animator _animator;

    // Use this for initialization
    void Start () {
		
	}

    /*
    void OnTriggerEnter(Collider meshhit)
    {
        if (meshhit.tag == "Slime")
        {
            //_animator.SetBool("TurnAround") = false;
            if ((_animator.GetBool("Turned") == true))
            {
                if (Global.guard_hitCurr == 1)
                {
                    gameObject.GetComponent<SkinnedMeshRenderer>().material = materialToChange[0];
                    print("Slimed once");
                }
                else if (Global.guard_hitCurr == 2)
                    gameObject.GetComponent<SkinnedMeshRenderer>().material = materialToChange[1];
                else if (Global.guard_hitCurr == 3)
                    gameObject.GetComponent<SkinnedMeshRenderer>().material = materialToChange[2];
                else if (Global.guard_hitCurr == 4)
                    gameObject.GetComponent<SkinnedMeshRenderer>().material = materialToChange[3];
            }
        }

    */


        void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Slime")
        {
            if (Global.guard_hitCurr == 1)
            {
                gameObject.GetComponent<SkinnedMeshRenderer>().material = materialToChange[0];
                print("Slimed once");
            }
            else if (Global.guard_hitCurr == 2)
                gameObject.GetComponent<SkinnedMeshRenderer>().material = materialToChange[1];
            else if (Global.guard_hitCurr == 3)
                gameObject.GetComponent<SkinnedMeshRenderer>().material = materialToChange[2];
            else if (Global.guard_hitCurr == 4)
                gameObject.GetComponent<SkinnedMeshRenderer>().material = materialToChange[3];
        }
    }

        // Update is called once per frame
        void Update () {
		
	}
}
