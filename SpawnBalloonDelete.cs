using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBalloonDelete : MonoBehaviour
{

    public Material[] materialToChange;
    public Animator _animator;
    //Renderer gameObjectToChange;

    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("TurnAround", false);
    }



    void OnTriggerEnter(Collider other3)
    {
        if (other3.tag == "Bullet")
        {

          //  _animator.SetBool("TurnAround", true);
          //  _animator.Play("Idle_IdleToIdlesR");
            gameObject.GetComponent<Renderer>().material = materialToChange[1];

            Global.balloonHit = true;

            Destroy(other3.gameObject);
            Destroy(gameObject);

  
        }
 
        if (other3.tag == "Slime")
        {


            gameObject.GetComponent<Renderer>().material = materialToChange[1];

            this.gameObject.GetComponent<Rigidbody>().useGravity = true;

            Global.balloonHit = true;
   
            StartCoroutine("killSelf");

      
        }

    }


    private IEnumerator killSelf()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
}