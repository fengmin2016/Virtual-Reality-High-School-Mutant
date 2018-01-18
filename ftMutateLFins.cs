using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ftMutateLFins : MonoBehaviour
{

    private SkinnedMeshRenderer fins;
    private bool yes;

    // Use this for initialization
    void Start()
    {
        fins = GetComponent<SkinnedMeshRenderer>();
        fins.enabled = false;
        yes = false;
    }

    private void Update()
    {
        if (mirrorGlobal.beenThere == true && yes == false)
        {
            StartCoroutine(secondWait());
            yes = true;
        }
    }

    private IEnumerator secondWait()
    {
        yield return new WaitForSeconds(9.63f);
        fins.enabled = true;
    }
}
