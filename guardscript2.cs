using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardscript2 : MonoBehaviour {

    public Animator _animator;
    bool hasBeenHit = false;
    bool startBossFight = false;
    bool hasBossStarted = false;
    public ParticleSystem bodysparks;
    public ParticleSystem plasmaexplosion;
    public ParticleSystem plasmaexplosioninGYM1;
    public GameObject CameraRig;
    public GameObject BalloonArch;
    public GameObject BlueDummy;
    public GameObject RedDummy;
    public TelePortalscript FinalBossPlayerPos;
    public TelePortalscript Gym1PlayerStartPos;
    public TelePortalscript VictoryTeleport;
    private Vector3 BossStartPos;

    public AudioSource Handcuffs;
    public AudioSource Block;
    public AudioSource DefeatAudio;
    public AudioSource DodgeLeft;
    public AudioSource DodgeRight;
    public AudioSource ElectricHit;
    public AudioSource WalkForward;
    public AudioSource SlimeHit;
    public AudioSource TurnedAudio;
    public AudioSource StayBack;
    public AudioSource WhatAreYou;
    //public AudioSource WhatWasThat;
    public AudioSource WhosInHere;






    // Use this for initialization
    void Start()
    {
        //_animator = GetComponent<Animator>();
        // _animator.SetBool("DodgeRight", false);
        // _animator.SetBool("DodgeLeft", false);
        //  _animator.SetBool("TakeHit", false);
        _animator.SetBool("TurnLeft", false);
        _animator.SetBool("TurnRight", false);
        _animator.SetBool("Defeat", false);
        _animator.SetBool("GotHit", false);
        //ParticleSystem.EmissionModule em = bodysparks.emission;
        // em.enabled = false;

        this.VictoryTeleport.gameObject.SetActive(false);
        this.FinalBossPlayerPos.gameObject.SetActive(false);
        this.Gym1PlayerStartPos.AlternateEndingLocation = this.FinalBossPlayerPos;
        this.BossStartPos = gameObject.transform.position;
        // _animator = GetComponentInParent<Animator>();

        if (Time.timeSinceLevelLoad < 10f)
        {
            Handcuffs = GetComponent<AudioSource>();
            Handcuffs.PlayOneShot(Handcuffs.clip);
        }
    }
    // Update is called once per frame

    void Update()
    {
        if (Global.balloonHit == true)
        {
            //print("got to GlobalHitScript");
            Global.balloonHit = false;
           // _animator.SetBool("TurnLeft", true);
            _animator.Play("TurnLeft");
            StartCoroutine(waitTurnLeft());
        }
        if (Global.balloonHitRight == true)
        {
            //print("got to GlobalRIGHTHitScript");
            Global.balloonHitRight = false;
            //_animator.SetBool("TurnRight", true);
            _animator.Play("TurnRight");
            StartCoroutine(waitTurnRight());
        }
        if (!hasBossStarted)
        {
            var dist = (Camera.main.transform.position - this.FinalBossPlayerPos.transform.position).magnitude;
            if ((dist < 12.0f) || (Input.GetKey(KeyCode.B)))
            {
                this.hasBossStarted = true;
                Global.startBossFight = true;
                plasmaexplosioninGYM1.Play();


            }
        }
        if (Global.startBossFight == true)
        {
            //startboss fight once you reach particular teleport zone
            print("got to StartFight");
            Global.startBossFight = false;
            _animator.SetBool("StartPlasma", true);
            StartCoroutine(PlasmaBlast());
        }

        //check if animation is complete
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("TurnLeft"))
        {
            _animator.SetBool("Turned", true);
            TurnedAudio.Play();
            //StartCoroutine(waitTurnLeft());
            //animation done playing
            // if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99)
            // {
            //     _animator.SetBool("TurnLeft", false);
            //     hasBeenHit = false;
            // }
        }
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("TurnRight"))
        {
            _animator.SetBool("Turned", true);
            TurnedAudio.Play();
            // StartCoroutine(waitTurnRight());
            //animation done playing
            // if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99)
            //{
            //   print("GOT HERE YOO");
            //   _animator.SetBool("TurnRight", false);
            //  hasBeenHit = false;
            // }
        }
        //turn off GotHit at Idle
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("GameIdle"))
        {
            _animator.SetBool("GotHit", false);
            hasBeenHit = false;
            StopAllCoroutines();
        }

        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("FirstIdle"))
        {
            this.FinalBossPlayerPos.DoTeleportHere();
            WhosInHere.Play();
            //float startcx = CameraRig.transform.position.x;
            //float startcy = CameraRig.transform.position.y;
            //float startcz = CameraRig.transform.position.z;
            //startcx = 22.29f;
            //startcy = -0.707f;
            //startcz = -74.97f;
            //CameraRig.transform.position = new Vector3(startcx, startcy, startcz);

            print("gottoFIRSTidle");
   
            float balloonmove = BalloonArch.transform.position.z;
            //balloonmove += 80f/84;
            BalloonArch.transform.position = new Vector3(BalloonArch.transform.position.x, BalloonArch.transform.position.y, BalloonArch.transform.position.z +80f/84);

            gameObject.transform.position = BossStartPos;
        }
        /*
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("SecondIdle"))
        {
            WhatAreYou.Play();
        }
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("DodgeLeft"))
        {
            DodgeLeft.Play();
        }
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("DodgeRight"))
        {
            DodgeRight.Play();
        }
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Block"))
        {
            Block.Play();
        }
        */
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Walk"))
        {
            print("gottowalkforward");
            float walkmove = gameObject.transform.position.x;
            walkmove -= 1.69f/34;
            gameObject.transform.position = new Vector3(walkmove, gameObject.transform.position.y, gameObject.transform.position.z);
            _animator.SetBool("Turned", false);
        }

        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Idle1"))
        {
            print("gottoIDLEEE");
            //StayBack.Play();
        }


        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Exit"))
        {
            print("gottoEXIT");
            //maybe play glowing particle to show the light at the end of the tunnel??
           // _animator.SetBool("Turned", false);
           // _animator.enabled = false;
            
        }
    }

    public int hitAmount_Max = 2; // TODO: make this 3 again
    private int hitAmount_Cur = 0;
    //public GameObject position1;
    //private GameObject postion1;

    IEnumerator waitTurnRight()
    {
        print("got to wait turn right");
        yield return new WaitForSeconds(3.0f);
        _animator.SetBool("TurnRight", false);
        //StopAllCoroutines();
    }

    IEnumerator waitTurnLeft()
    {
        print("got to wait turn left");
        yield return new WaitForSeconds(3.0f);
        _animator.SetBool("TurnLeft", false);
        //StopAllCoroutines();
    }

    IEnumerator BossDead()
    {
        print("Bosssss iss deadddddd");
        _animator.SetBool("Defeat", true);
        yield return new WaitForSeconds(4.0f);
        this.VictoryTeleport.gameObject.SetActive(true);
        this.VictoryTeleport.IsAlwaysShow = true;
        this.gameObject.SetActive(false);

        //StopAllCoroutines();
    }

    IEnumerator PlasmaBlast()
    {
        yield return new WaitForSeconds(0f);
        plasmaexplosion.Play();

    }

    void OnTriggerEnter(Collider meshhit)
    {
        if (meshhit.tag == "Slime" || meshhit.tag == "Bullet")
        {
            //_animator.SetBool("TurnAround") = false;
            if ((_animator.GetBool("Turned") == true && !hasBeenHit))
            {
                hasBeenHit = true;
                _animator.SetBool("GotHit", true);
                _animator.Play("GotHit");
               // StartCoroutine(wait());

                hitAmount_Cur++;
                print("HIT AMOUNT " + hitAmount_Cur);

                if (hitAmount_Cur >= hitAmount_Max)
                {
                    // You got hit too many times, it's over
                    StartCoroutine(BossDead());
                    DefeatAudio.Play();
                    Debug.Log("Yay, boss is dead");
                    //PLAY DEFEAT SCRIPT
                }
            }
        }
        if (meshhit.tag == "Bullet")
        {
            if (_animator.GetBool("Turned") == true)
            {
                //RUN PARTICLE SCRIPT HIT
                bodysparks.Play();
                ElectricHit.Play();
            }
        }
        if (meshhit.tag == "Slime")
        {
            if (_animator.GetBool("Turned") == true)
            {
                //RUN PARTICLE SCRIPT HIT
                SlimeHit.Play();
            }
        }
        if (meshhit.tag == "Arm")
        {
            print("going back");
            hitAmount_Cur = 2;
            _animator.Play("FirstIdle");
        }
        // _animator.SetBool("RunForward", false);
        // _animator.Play("Idle_Neutral_1 0");
        //   Debug.Log("door opened");
    }
}
// Update is called once per frame
//   void Update()
//      {

//     }