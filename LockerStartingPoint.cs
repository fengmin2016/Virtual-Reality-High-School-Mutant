using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerStartingPoint : MonoBehaviour {

    public TelePortalscript StartAtLocation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.frameCount == 2)
        {
            if (this.StartAtLocation != null)
            {
                this.StartAtLocation.DoTeleportHere();
            }
        }
	}
}
