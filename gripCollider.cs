using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gripCollider : MonoBehaviour {

    private SteamVR_TrackedController controller;
    private BoxCollider bcol;

    // Use this for initialization
    void Start () {
        controller = GetComponent<SteamVR_TrackedController>();
        controller.Gripped += Grab;
        controller.Ungripped += Release;
        bcol = GetComponent<BoxCollider>();
    }

    void Grab(object sender, ClickedEventArgs e)
    {
        StartCoroutine(waitON());
    }

    void Release(object sender, ClickedEventArgs e)
    {
        StartCoroutine(waitOFF());
    }

    IEnumerator waitON()
    {
        yield return new WaitForSeconds(0.1f);
        print("turning off");
        bcol.enabled = false;
    }

    IEnumerator waitOFF()
    {
        yield return new WaitForSeconds(2.0f);
        print("turning back on");
        bcol.enabled = true;
    }
}
