using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ftMutate : MonoBehaviour {

    public Material[] materialToChange;
    private bool yes;


    // Use this for initialization
    void Start()
    {
        yes = false;
	}

    private void Update()
    {
        if (mirrorGlobal.beenThere == true && yes == false)
        {
            StartCoroutine(firstWait());
            StartCoroutine(secondWait());
            yes = true;
        }
    }

    private IEnumerator firstWait()
    {
        yield return new WaitForSeconds(4.07f);
        gameObject.GetComponent<Renderer>().material = materialToChange[1];
    }

    private IEnumerator secondWait()
    {
        yield return new WaitForSeconds(9.63f);
        gameObject.GetComponent<Renderer>().material = materialToChange[2];
    }
}
