using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorGag : MonoBehaviour
{

    public GameObject normMirror;
    public GameObject gagMirror;
    public GameObject mirrorLR;
    public ParticleSystem TransformParticles;
    public ParticleSystem ElectricTransform;
    public ParticleSystem TransformPtHere;
    public ParticleSystem ElectricPtHere;
    public ParticleSystem handSparks;
    public GameObject L_web;
    public GameObject L_fin;
    public GameObject R_web;
    public GameObject R_fin;
    public GameObject Gym1;
    public GameObject Gym2;

    private AudioSource gagAud;
    private Color cBlue = new Color(0.0f, 0.0f, 0.005f, 1.0f);

    // Use this for initialization
    void Start()
    {
        gagAud = GetComponent<AudioSource>();
        gagMirror.SetActive(false);
        mirrorLR.SetActive(true);
        normMirror.SetActive(true);
        StartCoroutine(activewait());
        mirrorGlobal.beenThere = false;
        mirrorGlobal.isDuringMirrorGag = false;
        L_web.SetActive(false);
        L_fin.SetActive(false);
        R_web.SetActive(false);
        R_fin.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Arm" && mirrorGlobal.beenThere == false)
        {
            print("Here we go!");
            //mirrorLR.SetActive(true);
            gagMirror.SetActive(true);
            normMirror.SetActive(false);
            mirrorGlobal.beenThere = true;
            TransformParticles.Play();
            ElectricTransform.Play();
            TransformPtHere.Play();
            ElectricPtHere.Play();
            gagAud.Play();
            StartCoroutine(mirrorWait());
        }
    }

    IEnumerator mirrorWait()
    {
        mirrorGlobal.isDuringMirrorGag = true;
        yield return new WaitForSeconds(9.63f);
        mirrorGlobal.isDuringMirrorGag = false;
        L_web.SetActive(true);
        L_fin.SetActive(true);
        R_web.SetActive(true);
        R_fin.SetActive(true);
        handSparks.Play();
        yield return new WaitForSeconds(5.37f);
        //print("Mirror gag complete");
        //fade headset somehow -- how do i get the vrtk script called here?
        VRTK.VRTK_SDK_Bridge.GetHeadsetSDK().HeadsetFade(cBlue, 0.4f, false);
        yield return new WaitForSeconds(0.4f);
        VRTK.VRTK_SDK_Bridge.GetHeadsetSDK().HeadsetFade(Color.clear, 0.4f, false);
        mirrorLR.SetActive(false);
        gagMirror.SetActive(false);
        normMirror.SetActive(true);
        Gym1.SetActive(true);
        //Gym2.SetActive(true);
    }

    IEnumerator activewait()
    {
        yield return new WaitForSeconds(2f);
        Gym1.SetActive(false);
        Gym2.SetActive(false);
    }
}
