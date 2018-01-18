using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandFading : MonoBehaviour {

    public bool handHasFaded = false;
    public Material mutateHands;
    //public ParticleSystem handSparks;
    private Material handMat;
    private SkinnedMeshRenderer handModel;
    private bool isMutantHands;

    // Use this for initialization
    void Start()
    {
        //Set Alpha to 1
        handModel = GetComponent<SkinnedMeshRenderer>();
        handModel.material.SetFloat("anything", 0);
        handMat = handModel.material;
        Color color = handMat.color;
        color.a = 1;
        handMat.color = color;
        handMat.SetInt("_ZWrite", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(mirrorGlobal.beenThere != isMutantHands)
        {
            isMutantHands = mirrorGlobal.beenThere;
            handModel.sharedMaterial = mutateHands;
            handModel.material.SetFloat("anything", 0);
            handMat = handModel.material;
            StartCoroutine(AlphaFade(false));
        }

        bool showHandNow = GetComponentInParent<ControllerGrabObject>().isGrabbing || mirrorGlobal.isDuringMirrorGag;

        //DISAPPEAR HAND
        if (showHandNow && !handHasFaded)
            {
            handHasFaded = true;
            StopAllCoroutines();
            //change to transparent
            //set to transparent
            StartCoroutine("AlphaFade", true);
           
        }
        //MAKE HAND APPEAR
        else if (!showHandNow && handHasFaded)
         
        {
            handHasFaded = false;
            StopAllCoroutines();
            StartCoroutine("AlphaFade", false);
            handModel.enabled = true;
        }
    }

    IEnumerator AlphaFade(bool fadeOut)
    {
        float deltaAlpha = Time.deltaTime / 0.25f;
        if (fadeOut)
        {
            handMat.SetInt("_ZWrite", 0);
            while (handMat.color.a != 0 && handMat.color.a > 0)
            {
                Color color = handMat.color;
                color.a -= deltaAlpha;
                handMat.color = color;
                if (handMat.color.a < 0.0001)
                {
                    handModel.enabled = false;
                    
                }
                yield return null;
            }
        }
        else
        {
            while (handMat.color.a != 1 && handMat.color.a < 1)
            {
                Color color = handMat.color;
                color.a += deltaAlpha;
                handMat.color = color;
                //handSparks.Play();
                if (handMat.color.a > 0.99)
                {
                    //enable mesh renderer
                    handModel.enabled = true;
                    //handSparks.Play();
                    
                }

                yield return null;
            }
            handMat.SetInt("_ZWrite", 1);
        }
    }
}
