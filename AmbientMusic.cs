using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientMusic : MonoBehaviour {

    public GameObject normalAud;
    public GameObject bossAud;
    public GameObject endAud;

    private bool check1;
    private bool check2;

	// Use this for initialization
	void Start () {
        normalAud.SetActive(true);
        check1 = false;
        check2 = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Global.switchAud == true)
        {
            if(check1 == false)
            {
                normalAud.SetActive(false);
                bossAud.SetActive(true);
                check1 = true;
            }

            else if(Global.endAud == true && check2 == false)
            {
                bossAud.SetActive(false);
                endAud.SetActive(true);
                check2 = true;
            }
        }
	}
}
