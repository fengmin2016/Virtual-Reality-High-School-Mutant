using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puppetHead : MonoBehaviour
{

    public Transform target;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newrotation = new Vector3((target.transform.eulerAngles.z) * -1, (target.transform.eulerAngles.y) + 90, (target.transform.eulerAngles.x) - 90);
        this.transform.eulerAngles = newrotation;
       
    }
}
