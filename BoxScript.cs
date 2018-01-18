using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public Animator _animator;
    // bool hasBeenHit = false;
    // Use this for initialization
    void Start()
    {
        // _animator = GetComponent<Animator>();
        _animator.SetBool("DodgeRight", false);
        _animator.SetBool("DodgeLeft", false);
        _animator.SetBool("TakeHit", false);
        _animator.SetBool("TurnAround", false);
        // _animator = GetComponentInParent<Animator>();
    }
    // Update is called once per frame

    void Update()
    {
        //print("hellow world 333");
    }

    // public int hitAmount_Max = 4;
    //  private int hitAmount_Cur = 0;

    void OnTriggerEnter(Collider boxhit)
    {
        if (boxhit.tag == "Slime")
        {

            if (_animator.GetBool("TurnAround") == true)
            {

            }
            else
            {
                //Random rnd = new Random();
                int R = (int)Random.Range(0, 3);
                if (R == 0)
                {
                    _animator.SetBool("DodgeRight", true);
                    _animator.Play("Idle2Strafe_AllAngles");
                    _animator.SetBool("DodgeRight", false);
                }
                else if (R == 1)
                {
                    _animator.SetBool("DodgeLeft", true);
                    _animator.Play("Idle2Strafe_AllAngles 0");
                    _animator.SetBool("DodgeLeft", false);
                }
                else if (R == 2)
                {
                    _animator.SetBool("TakeHit", true);
                    _animator.Play("Idle_CannotDown_Idle");
                    _animator.SetBool("TakeHit", false);
                }
            }
        }
        if (boxhit.tag == "Bullet")
        {
            if (_animator.GetBool("TurnAround") == true)
            {
                //Stun script
            }
            else
            {
                //Random rnd = new Random();
                int R = (int)Random.Range(0, 3);
                if (R == 0)
                {
                    _animator.SetBool("DodgeRight", true);
                    _animator.Play("Idle2Strafe_AllAngles");
                    _animator.SetBool("DodgeRight", false);
                }
                else if (R == 1)
                {
                    _animator.SetBool("DodgeLeft", true);
                    _animator.Play("Idle2Strafe_AllAngles 0");
                    _animator.SetBool("DodgeLeft", false);
                }
                else if (R == 2)
                {
                    _animator.SetBool("TakeHit", true);
                    _animator.Play("Idle_CannotDown_Idle");
                    _animator.SetBool("TakeHit", false);
                }
            }
        }
        // _animator.SetBool("RunForward", false);
        // _animator.Play("Idle_Neutral_1 0");
        //   Debug.Log("door opened");
    }
}
// Update is called once per frame
//   void Update()
//      {

//     }
