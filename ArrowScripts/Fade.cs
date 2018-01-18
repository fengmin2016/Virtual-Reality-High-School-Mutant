using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

    public Material arrowMat;
    public Renderer arrow;
    
    //public Shader arrow;

    public GameObject currentTip;

    // Use this for initialization
    void Start()
    {
        Color col = arrowMat.color;
        col.a = 0;
        arrowMat.color = col;


        //arrow = GetComponentInChildren<Renderer>().material.shader;

        //arrow = transform.GetChild(0).GetChild(0).GetComponent<Renderer>();

    }
   

    // Update is called once per frame
    void Update() {

        if (currentTip != null)
        {
            if (!currentTip.activeSelf)
            {
                StartCoroutine(constantFading(false));
                currentTip = null;
            }
        }
    }
    
    public void OnTriggerEnter(Collider other)
    {    
        if (other.tag == "LaserTip")
        {
            StopAllCoroutines();
            if (other.gameObject.name == "LaserTip_Left")
                currentTip = GameObject.Find("[LeftController]BasePointer_Origin_Smoothed");
            else if (other.gameObject.name == "LaserTip_Right")
                currentTip = GameObject.Find("[RightController]BasePointer_Origin_Smoothed");

            StartCoroutine(constantFading(true)); 
        } 
    }
    //when you teleport, OnTriggerExit never gets executed which means the arrow doesn't fade out
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "LaserTip")
        {
            StopAllCoroutines();
            StartCoroutine(constantFading(false));
        }
    }
    

    IEnumerator StopArrow()
    {
        yield return new WaitForSeconds(0);
        //Destroy(gameObject);
        //yield return null;
    }


    //0.3f works on both but nothing else

    IEnumerator constantFading(bool active)
    {
        if (active)
        {
            while (arrowMat.color.a < 1)
            {
                Color col = arrowMat.color;
                col.a += 0.3f;
                arrowMat.color = col;
                yield return null;
            }
        }
        if (!active)
        {
            while (arrowMat.color.a > 0)
            {
                Color col = arrowMat.color;
                col.a -= 0.3f;
                arrowMat.color = col;
                StartCoroutine("StopArrow");
                yield return null;
            }
        }
    }
}

