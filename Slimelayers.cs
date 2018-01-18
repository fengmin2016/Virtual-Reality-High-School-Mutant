using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slimelayers : MonoBehaviour {
    public Material[] materialToChange;
    public AudioClip slimeSoundTD;
    private AudioSource tdAud;

    public int count = 0;
    //Renderer rend;
    //MeshRenderer thing;
	// Use this for initialization
	void Start () {
        tdAud = GetComponent<AudioSource>();
       // thing = GetComponent<MeshRenderer>();
        
        //rend = GetComponent<Render>();
       // rend.enable = false;
	}
	
    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Slime")
        {
            //Play slime sound
            if (tdAud != null)
            {
                tdAud.clip = slimeSoundTD;
                tdAud.Play();
            }
            //gameObject.GetComponent<Renderer>().material = materialToChange[0];

            // rend.enable = true;
            if (count == 0)
                gameObject.GetComponent<Renderer>().material = materialToChange[0];
                //thing.material = materialToChange[0];
            else if (count == 1)
                gameObject.GetComponent<Renderer>().material = materialToChange[1];
                //thing.material = materialToChange[1];
            else if (count == 2)
                gameObject.GetComponent<Renderer>().material = materialToChange[2];
                //thing.material = materialToChange[2];


            Debug.Log("ChangeMaterial");
            count = count + 1;

        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
