using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radioPlay : MonoBehaviour {

    public AudioClip[] song;

    private AudioSource bboxAud;
    private AudioClip choice;
    private int index;
    private Animator bboxAnim;

	// Use this for initialization
	void Start () {
        bboxAud = GetComponent<AudioSource>();
        bboxAnim = GetComponent<Animator>();
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            index = Random.Range(0, song.Length);
            choice = song[index];
            bboxAud.clip = choice;
            //print(song[index] + "||");
            bboxAud.Play();
            bboxAnim.SetBool("isPlaying", true);
            bboxAnim.Play("playMusicANIM");
        }
        bboxAnim.SetBool("isPlaying", false);
    }
}
