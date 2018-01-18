using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : MonoBehaviour
{
    public GameObject drip;
    public GameObject particle;


    // Use this for initialization
    void Start()
    {
    }

    private IEnumerator killSelf()
    {
        yield return new WaitForSeconds(0.0001f);
        //print("GOT HERE YOO");
        particle.transform.parent = null;
        Destroy(gameObject);
    }

    



/*
IEnumerator Fade()
{
    fading = true;
    Color fromColor = faded ? fadedColor : solidColor;
    Color toColor = faded ? solidColor : fadedColor;
    for (var t = 0f; t < fadeTime; t += Time.deltaTime)
    {
        myRenderer.material.color = Color.Lerp(fromColor, toColor, t / fadeTime);
        yield return null;
    }
    fading = false;
    faded = !faded;
}

Fadeto:
float alpha = transform.renderer.material.color.a;
    for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
    {
        Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
        transform.renderer.material.color = newColor;
        yield return null;
*/



// Update is called once per frame
void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, fwd, Color.green);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, fwd, out hit, 0.5f))
        {
            if (hit.collider.tag != "Balloon" && hit.collider.tag != "Dummy" && hit.collider.tag != "Boss" && hit.collider.tag != "DistractionObject" && hit.collider.tag != "PunchingBag")
            {
                GameObject splatter;
                splatter = Instantiate(drip, hit.point + (hit.normal * 0.1f), Quaternion.FromToRotation(Vector3.up, hit.normal));

                var scaler = Random.Range(0,0.1f);
                splatter.transform.localScale = new Vector3(splatter.transform.localScale.x * scaler, splatter.transform.localScale.y, splatter.transform.localScale.z * scaler);

                var rater = Random.Range(0, 100);
                splatter.transform.RotateAround(hit.point, hit.normal, rater);

                Destroy(splatter, 4);

            }
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