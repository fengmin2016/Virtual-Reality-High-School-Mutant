using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime_splat : MonoBehaviour
{
    public GameObject drip;
    // Use this for initialization
    void Start()
    {
    }

    private IEnumerator killSelf()
    {
        yield return new WaitForSeconds(0.0001f);
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Random.onUnitSphere * 5);
        Debug.DrawRay(transform.position, fwd, Color.green);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, fwd, out hit, 0.7f))
        {
            GameObject splatter;
             splatter = Instantiate(drip, hit.point + (hit.normal *  0.1f), Quaternion.FromToRotation(Vector3.up, hit.normal));

            var scaler = Random.value;
            splatter.transform.localScale = new Vector3(splatter.transform.localScale.x * scaler, splatter.transform.localScale.y, splatter.transform.localScale.z * scaler);

            var rater = Random.Range(0, 359);
            splatter.transform.RotateAround(hit.point, hit.normal, rater);

            Destroy(splatter, 5);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       // if(other.tag == "Bullet")
    }

    //If hit something
    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine("killSelf");
    }
}