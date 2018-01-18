using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public Animator _animator;
    bool hasBeenHit = false;
    // Use this for initialization
    void Start()
    {
        //_animator = GetComponent<Animator>();
       // _animator.SetBool("DodgeRight", false);
       // _animator.SetBool("DodgeLeft", false);
      //  _animator.SetBool("TakeHit", false);
        _animator.SetBool("TurnAround", false);
        _animator.SetBool("TurnAroundRight", false);
        // _animator = GetComponentInParent<Animator>();
    }
    // Update is called once per frame

    void Update()
    {
        //print("hellow world 333");
        if (Global.balloonHit == true)
        {
            print("got to OLDBOSSGlobalHitScript");
            Global.balloonHit = false;

            _animator.SetBool("TurnAround", true);
            _animator.Play("Idle_IdleToIdlesR");

            // print("GOT HERE 22");
            // print(_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle_IdleToIdlesR"));
            // _animator.SetBool("TurnAround", false);
            // _animator.Play("Idle_Neutral_1 0");
            //  _animator.SetBool("RunForward", true);
            // _animator.Play("Run_Impulse 0");
        }
        if (Global.balloonHitRight == true)
        {
            print("got to OLDBOSSGlobalRIGHTHitScript");
            Global.balloonHitRight = false;

            _animator.SetBool("TurnAroundRight", true);
            _animator.Play("Idle_IdleToIdlesR 0");
        }

        //check if animation is complete
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle_IdleToIdlesR"))
        {
            //animation done playing
            if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99)
            {
                _animator.SetBool("TurnAround", false);
                hasBeenHit = false;
            }
        }
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle_IdleToIdlesR 0"))
        {
            //animation done playing
            if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99)
            {
                _animator.SetBool("TurnAroundRight", false);
                hasBeenHit = false;
            }
        }
    }

    public int hitAmount_Max = 4;
    private int hitAmount_Cur = 0;

    void OnTriggerEnter(Collider meshhit)
    {
        if (meshhit.tag == "Slime")
        {
            //_animator.SetBool("TurnAround") = false;

            if (_animator.GetBool("TurnAround") == true && !hasBeenHit)
            {
                hasBeenHit = true;
                hitAmount_Cur++;
                print("HIT AMOUNT " + hitAmount_Cur);

                if (hitAmount_Cur >= hitAmount_Max)
                {
                    // You got hit too many times, it's over
                    Debug.Log("Yay, boss is dead");
                    Destroy(gameObject);
                }
            }
            if (_animator.GetBool("TurnAroundRight") == true && !hasBeenHit)
            {
                hasBeenHit = true;
                hitAmount_Cur++;
                print("HIT AMOUNT " + hitAmount_Cur);

                if (hitAmount_Cur >= hitAmount_Max)
                {
                    // You got hit too many times, it's over
                    Debug.Log("Yay, boss is dead");
                    Destroy(gameObject);
                }
            }
        }
        if (meshhit.tag == "Bullet")
        {
            if (_animator.GetBool("TurnAround") == true)
            {
                //Stun script
            }
            if (_animator.GetBool("TurnAroundRight") == true)
            {
                //Stun script
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