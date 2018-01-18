using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BalloonDelete: MonoBehaviour {

    public Material[] materialToChange;
    private bool hastransation = false;

    public AudioClip popElec;
    public AudioClip popSlime;
    private AudioSource balloonAud;

    // Use this for initialization
    void Start () {
        balloonAud = GetComponent<AudioSource>();
        //Global.gymballoon_counter = 0;
        //Global.dummyCount = 0;
        Global.balloon_counter = 0;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet" || other.tag == "Slime")
        {
            //Global.balloon_counter++;
            Debug.Log("sime touch balloon");
            if(this.gameObject.layer == LayerMask.NameToLayer("balloonArch"))
            {
                //Global.gymballoon_counter++;
                Debug.Log("sime touch gym balloon");
  
            }
           // if (Global.gymballoon_counter >= 5 && Global.dummyCount >= 2)
            {
            //    if (!this.hastransation)
             {
           //         this.hastransation = true;
            //        Debug.Log("Loading new scene.");
                    //SceneManager.LoadScene("SuperVolcano_LightingScene", LoadSceneMode.Additive);
                    //SceneManager.LoadScene("SuperVolcano_LightingScene");
                }
            }
        }


        if (other.tag == "Bullet")
        {
            gameObject.GetComponent<Renderer>().material = materialToChange[0];
            //Destroy(other.gameObject);
            //Destroy(gameObject);
            //Assign electric pop sound to audio clip


            balloonAud.clip = popElec;
            balloonAud.Play();
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
            StartCoroutine("ElecBalloonKill");
        }

        if (other.tag == "Slime")
        {
            //Change balloon's material
            gameObject.GetComponent<Renderer>().material = materialToChange[1];
            //Assign slime pop sound to audio clip
            balloonAud.clip = popSlime;
            balloonAud.Play();
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
            StartCoroutine("SlimeBalloonKill");
        }

    }

    private IEnumerator ElecBalloonKill()
    {
        yield return new WaitForSeconds(0.2f);
       // balloonAud.Play();
        Destroy(gameObject);
    }

    private IEnumerator SlimeBalloonKill()
    {
        yield return new WaitForSeconds(1.0f);
       // balloonAud.Play();
        Destroy(gameObject);
    }
}
