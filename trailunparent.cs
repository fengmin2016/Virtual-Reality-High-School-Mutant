using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailunparent : MonoBehaviour {

    public bool startTimerLock = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (startTimerLock && transform.parent == null)
        {
            StartCoroutine("killParticle");
            startTimerLock = false;
        }
	}

    public IEnumerator killParticle()
    {
        yield return new WaitForSeconds(1f);
        print("I got here");
        Destroy(gameObject);
    }
}
