using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_handAnim : MonoBehaviour
{

    public SteamVR_TrackedController controller;
    private Animator _animator;
    //private float fadeTime = 0.5f;
    //public SkinnedMeshRenderer LHandRend;


    // Use this for initialization
    void Start()
    {
        controller = GetComponent<SteamVR_TrackedController>();
        _animator = GetComponent<Animator>();
        _animator.enabled = true;
        //LHandRend = GetComponent<SkinnedMeshRenderer>();
        //var handcolor = handMat.color;
    }

    private void OnEnable()
    {
        controller.TriggerClicked += handleTriggerClicked;
        controller.Gripped += handleGrip;
        controller.Ungripped += handleUngrip;
    }

    void handleTriggerClicked(object sender, ClickedEventArgs e)
    {
        //print("You clicked the trigger.");
        if(mirrorGlobal.beenThere == true)
        {
            _animator.SetBool("isShoot", true);
            _animator.Play("L_shoot");
            _animator.SetBool("isShoot", false);
        }
    }

    void handleGrip(object sender, ClickedEventArgs e)
    {
        //var handMat = LHandRend.material;
        //var handColor = handMat.color;

        _animator.SetBool("isGrab", true);
        _animator.Play("L_grab");
        //handMat.color = new Color(handColor.r, handColor.g, handColor.b, handColor.a - (fadeTime * Time.deltaTime));
    }

    void handleUngrip(object sender, ClickedEventArgs e)
    {
        //var handMat = LHandRend.material;
        //var handColor = handMat.color;

        //print("Checking to see if grab");
        if (_animator.GetBool("isGrab") == true)
        {
            //print("Getting ready to release");
            _animator.SetBool("isRelease", true);
            _animator.Play("L_release");
            _animator.SetBool("isGrab", false);
            _animator.SetBool("isRelease", false);
            //handMat.color = new Color(handColor.r, handColor.g, handColor.b, handColor.a + (fadeTime * Time.deltaTime));
        }
    }


}

