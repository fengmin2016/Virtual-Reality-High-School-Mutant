using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electricity : MonoBehaviour {

    public GameObject particle;
    // Use this for initialization
    void Start () {
	}

    
    private IEnumerator electrickill()
    {
        yield return new WaitForSeconds(0.40f);
        print("ShortTravel");
        particle.transform.parent = null;
        Destroy(gameObject);
    }
    private IEnumerator killSelf()
    {
        yield return new WaitForSeconds(2.50f);
        print("LONG Travel");
        particle.transform.parent = null;
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update () {
		
	}

   // private void OnTriggerEnter(Collider other)
   // {
        // if(other.tag == "Bullet")
    //}

    //If hit something
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Balloon" || collision.gameObject.tag == "Boss" || collision.gameObject.tag == "DistractionObject")
        {
            StartCoroutine("electrickill");
        }

        else
        {
            StartCoroutine("killSelf");
        }
    }
}
