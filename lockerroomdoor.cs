using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockerroomdoor : MonoBehaviour
{
    private Animator _animator = null;
    private AudioSource LRdoorAud;
    bool doorOpen = false;
    public TelePortalscript GohereAfterOpen = null;
    public GameObject MirrorLockerRoom;
    public GameObject Gym2;

    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("isopen", false);
        LRdoorAud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        print("BALLOONS DESTROYED " + Global.balloon_counter);
        if (other.tag == "Arm" && doorOpen == false)// && Global.balloon_counter >= 21)
        {
            //if input of controller is grip
            //play open animation

           
            _animator.SetBool("isopen", true);
            _animator.Play("lockerroomdoor_open");
            doorOpen = true;
            LRdoorAud.Play();
            MirrorLockerRoom.SetActive(false);
            Gym2.SetActive(true);
            this.GetComponent<Collider>().enabled = false;
            this.StartCoroutine(AfterDoorOpens());
        }
    }

    IEnumerator AfterDoorOpens()
    {
        yield return new WaitForSeconds(0.5f);
        if (this.GohereAfterOpen != null)
        {
            this.GohereAfterOpen.DoSlowlyTeleport();
        }
    }
}

