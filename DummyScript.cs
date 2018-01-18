using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyScript : MonoBehaviour
{
    public Material[] materialToChange;
    public int count = 0;
    public Animator _animator;
    bool hasBeenHit = false;
    public bool DEBUG_TestHit = false;
    public AudioClip slimeSoundTD;
    public AudioClip shakeSoundTD;
    private AudioSource tdAud;


    //private AudioSource tdAud;

    //public AudioClip shakeSoundTD;

    // Use this for initialization
    void Start()
    {
        if (this._animator == null)
        {
            _animator = GetComponent<Animator>();
        }
        //_animator.enabled = false;
        _animator.SetBool("isShake", false);
        tdAud = GetComponent<AudioSource>();
        //tdAud = GetComponent<AudioSource>();
        //_animator.SetBool("isShake", false);
    }
    // Update is called once per frame

    public int hitAmount_Max = 3;
    private int hitAmount_Cur = 0;

    public void DoShakeBegin()
    {

        DEBUG_TestHit = false;
        _animator.enabled = true;
        _animator.SetBool("isShake", true);
    }

    void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "Slime" || collider.tag == "Bullet")
        {
                hasBeenHit = true;
                hitAmount_Cur++;
                print("HIT AMOUNT " + hitAmount_Cur);

                if (hitAmount_Cur >= hitAmount_Max)
                {
                    Debug.Log("Yay, dummy is dead");
                    //Global.dummyCount++;
                    Destroy(gameObject);
                    
            }
            
        }
        if ((collider.tag == "Bullet") || (DEBUG_TestHit))
        {
            tdAud.clip = shakeSoundTD;
            tdAud.Play();
            this.DoShakeBegin();
        }

        if (collider.tag == "Slime")
        {
            if (hitAmount_Cur == 1)
                gameObject.GetComponent<Renderer>().material = materialToChange[0];
            //thing.material = materialToChange[0];
            else if (hitAmount_Cur == 2)
                gameObject.GetComponent<Renderer>().material = materialToChange[1];
            //thing.material = materialToChange[1];
            else if (hitAmount_Cur == 3)
                gameObject.GetComponent<Renderer>().material = materialToChange[2];
            //thing.material = materialToChange[2];
        }
        if (collider.tag == "Slime")
        {
            tdAud.clip = slimeSoundTD;
            tdAud.Play();
        }

        }
    void Update()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Shake"))
        {
            _animator.SetBool("isShake", false);
        }

        if (this.DEBUG_TestHit)
        {
            this.DEBUG_TestHit = false;
            this.DoShakeBegin();
        }
    }

}