using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_handAnim : MonoBehaviour {

    public SteamVR_TrackedController controller;
    private Animator _animator;
    //private bool grabbing = false;

    // Use this for initialization
    void Start ()
    {
        controller = GetComponent<SteamVR_TrackedController>();
        //controller = SteamVR_TrackedController.Input((int)trackedObject.index);
        _animator = GetComponent<Animator>();
        _animator.enabled = true;
    }

    private void OnEnable()
    {
        controller.TriggerClicked += handleTriggerClicked;
        controller.Gripped += handleGrip;
        controller.Ungripped += handleUngrip;
    }

    void handleTriggerClicked(object sender, ClickedEventArgs e)
    {
        if(mirrorGlobal.beenThere == true)
        {
            _animator.SetBool("isShoot", true);
            _animator.Play("R_shoot");
            _animator.SetBool("isShoot", false);
        }
    }

    void handleGrip(object sender, ClickedEventArgs e)
    {
        _animator.SetBool("isGrab", true);
        _animator.Play("R_grab");
    }

    void handleUngrip(object sender, ClickedEventArgs e)
    {
        print("Checking to see if grab");
        if(_animator.GetBool("isGrab") == true)
        {
            print("Getting ready to release");
            _animator.SetBool("isRelease", true);
            _animator.Play("R_release");
            _animator.SetBool("isGrab", false);
            _animator.SetBool("isRelease", false);
        }
    }

}
