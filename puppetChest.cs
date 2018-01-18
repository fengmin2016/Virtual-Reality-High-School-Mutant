using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puppetChest : MonoBehaviour
{

    //public Transform target;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var target = Camera.main.transform;
        var fwd = target.localToWorldMatrix.MultiplyVector(Vector3.forward);
        var up = target.localToWorldMatrix.MultiplyVector(Vector3.up);

        //fwd.z *= -1.0f;
        //up.z *= -1.0f;
        fwd.y = 0.0f;
        up = Vector3.up;

        var rot = Quaternion.LookRotation(fwd, up);
        this.transform.rotation = rot;
        //Vector3 newrotation = new Vector3(target.transform.eulerAngles.x * 0.3f, target.transform.eulerAngles.y * 0.3f, target.transform.eulerAngles.z * 0.3f);

        //this.transform.eulerAngles = newrotation;
        

        //this.transform.Rotate(newrotation * 0.2f);

        // print(target.transform.rotation);
        //Quaternion newrotation = Quaternion.Euler(target.transform.eulerAngles.x, target.transform.eulerAngles.y, target.transform.eulerAngles.z);

        //print("chestRot " + new Vector3(target.transform.eulerAngles.x, target.transform.eulerAngles.y, target.transform.eulerAngles.z));
        //print("ChestRotOffset " + new Vector3(target.transform.eulerAngles.x * 0.99f, target.transform.eulerAngles.y * 0.99f, target.transform.eulerAngles.z * 0.99f));

    }
}
