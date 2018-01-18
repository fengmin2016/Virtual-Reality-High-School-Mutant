using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TelePortalscript : MonoBehaviour {

    //public Transform sparks;
    //private GameObject electriport;
    public GameObject AnyTeleportEffect;
    public GameObject OverTeleportEffect;
    public GameObject directArrow;
    private GameObject currentTip;
    private SteamVR_ControllerManager controllers;
    private SteamVR_TrackedController[] allHands;
    private bool mWasShowing;
    private bool mIsOverTeleport;
    private bool mWasPressing = false;
    private float mLastTimeOver = -10.0f;
    private Color cBlue = new Color(0.0f, 0.0f, 0.005f, 1.0f);
    [HideInInspector]
    public TelePortalscript AlternateEndingLocation = null;
    public bool IsAlwaysShow { get; set; }
    private bool soundHasPlayed;

    
    // Use this for initialization
    void Start()
    {
        //this.electriport = this.transform.GetChild(0).gameObject;
        this.controllers = GameObject.FindObjectOfType<SteamVR_ControllerManager>();
        this.allHands = (new GameObject[] { this.controllers.left, this.controllers.right }).Select(k => k.GetComponent<SteamVR_TrackedController>()).ToArray();
        this.UpdateParticles(false);

    }

    private void UpdateParticles(bool isOn)
    {
        this.mWasShowing = isOn;
        //this.electriport.SetActive(isOn);
        AnyTeleportEffect.SetActive(isOn || this.IsAlwaysShow);
        OverTeleportEffect.SetActive(isOn && this.mIsOverTeleport);
        directArrow.SetActive(isOn && this.mIsOverTeleport);
    }

    // Update is called once per frame
    void Update()
    {
        this.UpdateButtonsStates();

       if (currentTip != null)
       {
           if (!currentTip.activeSelf)
            {
                Debug.Log("OTHER NOT OVER");
                this.UpdateTeleportRelease(false);
                this.mIsOverTeleport = false;
                currentTip = null;
                
            }
       }

       if (this.mIsOverTeleport)
        {
            mLastTimeOver = Time.time;
        }

    }

    private void UpdateButtonsStates()
    {

        bool isPressed = false;
        {
            foreach (var hand in this.allHands)
            {
                if (hand.padPressed)
                {
                    isPressed = true;
                }
            }
        }
        if (this.mWasPressing != isPressed)
        {
            this.mWasPressing = isPressed;
            if (!isPressed)
            {
                var delayStillTeleport = 0.3f;
                if ((Time.time - this.mLastTimeOver) < delayStillTeleport)
                {
                    this.StartCoroutine(slowlyDoTeleport());
                    // Just to be sure:
                    this.mIsOverTeleport = false;
                    this.currentTip = null;
                    this.UpdateParticles(false);
                }
            }
        }
        this.UpdateTeleportRelease(isPressed);
    }

    private void UpdateTeleportRelease(bool isShowing) { 
        if (isShowing != this.mWasShowing)
        {
            this.mWasShowing = isShowing;
            if ((this.currentTip != null) && (!isShowing))
            {
                //Debug.Log("TRYING TO TELEPORT");
                //this.DoTeleportHere();
            }
            else
            {
                this.currentTip = null;
            }
        }
        this.UpdateParticles(isShowing);
    }

    public static Vector3 ZeroY(Vector3 v)
    {
        return new Vector3(v.x, 0.0f, v.z);
    }

    public void DoSlowlyTeleport()
    {
        this.StartCoroutine(slowlyDoTeleport());
    }

    IEnumerator slowlyDoTeleport()
    {
        VRTK.VRTK_SDK_Bridge.GetHeadsetSDK().HeadsetFade(cBlue, 0.4f, false);
        yield return new WaitForSeconds(0.4f);
        DoTeleportHere();
        VRTK.VRTK_SDK_Bridge.GetHeadsetSDK().HeadsetFade(Color.clear, 0.4f, false);
    }

    public void DoTeleportHere()
    {
        Debug.Log("DOING TELEPORT");

        if (this.AlternateEndingLocation != null)
        {
            this.AlternateEndingLocation.DoTeleportHere();
            return;
        }

        var cam = Camera.main.transform;
        var camBase = cam.parent;
        

        // Rotation:
        var toFwd = this.transform.forward;
        camBase.rotation = Quaternion.FromToRotation(ZeroY(cam.localRotation * Vector3.forward), ZeroY(toFwd));

        // Translocation:
        var toLoc = this.transform.position;
        var delta = toLoc - cam.position;
        delta.y = 0.0f;
        camBase.position += delta;

        if (!soundHasPlayed)
        {
            if (this.GetComponent<AudioSource>())
            {
                soundHasPlayed = true;
                this.GetComponent<AudioSource>().Play();
            }
        }
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LaserTip")
        {
            if (other.gameObject.name == "LaserTip_Left")
               currentTip = GameObject.Find("[LeftController]BasePointer_Origin_Smoothed");
            else if (other.gameObject.name == "LaserTip_Right")
                currentTip = GameObject.Find("[RightController]BasePointer_Origin_Smoothed");

            if (!mIsOverTeleport)
            {
                mIsOverTeleport = true;
                //print("OVER THE TELEPORTTTTTTT");
            }
            
            //this.UpdateParticles(true);
        }
    }
    //when you teleport, OnTriggerExit never gets executed which means the arrow doesn't fade out
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "LaserTip")
        {
            if (mIsOverTeleport)
            {
                this.UpdateTeleportRelease(false);
                mIsOverTeleport = false;
                //print("NOT THE TELEPORTTTTTTT");
            }

            currentTip = null;
        }
    }
}
