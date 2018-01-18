using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardscript : MonoBehaviour {

    public Animator _animator;
    bool hasBeenHit = false;
    bool startBossFight = false;
    bool hasBossStarted = false;
   // public GameObject Gym2;
    public GameObject Gym1;
    public GameObject LockerRoom1;
    public ParticleSystem bodysparks;
    public ParticleSystem plasmaexplosion;
    public ParticleSystem plasmaexplosioninGYM1;
    public GameObject CameraRig;
    public GameObject BalloonArch;
    //public GameObject BlueDummy;
    //public GameObject RedDummy;
    public GameObject beams;
    public GameObject bballgoal;
    public AudioClip goalFall;
    public TelePortalscript FinalBossPlayerPos;
    public TelePortalscript Gym1PlayerStartPos;
    public TelePortalscript VictoryTeleport;
    private Vector3 BossStartPos;
    public GameObject tryAgainScreen;
    public AudioClip[] BossFightClips;
    private AudioSource BossAudio;

    public Vector3 walkDest;

    // Use this for initialization
    void Start()
    {
        walkDest = new Vector3(0.0f, 0.0f, 0.0f);
        _animator.SetBool("TurnLeft", false);
        _animator.SetBool("TurnRight", false);
        _animator.SetBool("Defeat", false);
        _animator.SetBool("GotHit", false);
        beams.GetComponent<Animator>().SetBool("isFall", false);
        bballgoal.GetComponent<Animator>().SetBool("isFall", false);
        BossAudio = GetComponent<AudioSource>();
        tryAgainScreen.SetActive(false);

        this.VictoryTeleport.gameObject.SetActive(false);
        this.FinalBossPlayerPos.gameObject.SetActive(false);
        this.Gym1PlayerStartPos.AlternateEndingLocation = this.FinalBossPlayerPos;
        this.BossStartPos = gameObject.transform.position;
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
            if ((dist < 6.0f) || (Input.GetKey(KeyCode.B)))
            {
                this.hasBossStarted = true;
                Global.startBossFight = true;
                Global.switchAud = true;
                plasmaexplosioninGYM1.Play();


            }
        }
        if (Global.startBossFight == true)
        {
            //Gym2.SetActive(true);
            Gym1.SetActive(false);
            LockerRoom1.SetActive(false);
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
            //TurnedAudio.Play();
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
            //TurnedAudio.Play();
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
            //WhosInHere.Play();
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
        
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("SecondIdle"))
        {
            BossAudio.clip = BossFightClips[13];
            BossAudio.Play();
        }
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("DodgeLeft"))
        {
           // BossAudio.clip = BossFightClips[3];
            //BossAudio.Play();
        }
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("DodgeRight"))
        {
          //  BossAudio.clip = BossFightClips[4];
           // BossAudio.Play();
        }
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Defeat"))
        {


        }
        
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Walk"))
        {
            if (walkDest.x == 0.0f && walkDest.y == 0.0f && walkDest.z == 0)
                walkDest = new Vector3(transform.position.x - 1.1f, transform.position.y, transform.position.z);

            print("gottowalkforward");
           // BossAudio.clip = BossFightClips[6];
           // BossAudio.Play();
            //float walkmove = gameObject.transform.position.x;
            // walkmove -= 1.6f/20;
            //was 52
            //gameObject.transform.position = new Vector3(walkmove, gameObject.transform.position.y, gameObject.transform.position.z);

            float speed = 3.0f * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, walkDest, speed);

            if (Vector3.Distance(transform.position, walkDest) <= 0.2f)
            {
                walkDest = new Vector3(0, 0, 0);
            }

            
            _animator.SetBool("Turned", false);
        }

        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Walk") && Global.guard_hitCurr == 2)
        {
            BossAudio.clip = BossFightClips[0];
            BossAudio.Play();
        }
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Walk") && Global.guard_hitCurr == 1)
        {
            BossAudio.clip = BossFightClips[9];
            BossAudio.Play();
        }
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Hit") && Global.guard_hitCurr == 1)
        {
            BossAudio.clip = BossFightClips[10];
            BossAudio.Play();
        }
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Hit") && Global.guard_hitCurr == 3)
        {
            BossAudio.clip = BossFightClips[14];
            BossAudio.Play();
        }
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Idle1"))
        {
            print("gottoIDLEEE");
        }


        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Exit"))
        {
            print("gottoEXIT");
            //maybe play glowing particle to show the light at the end of the tunnel??
           // _animator.SetBool("Turned", false);
           // _animator.enabled = false;
            
        }
        if (Global.tryAgain == true)
        {
            print("gottoTRYAGAIN");
            tryAgainScreen.SetActive(true);
            this.StartCoroutine(WaitThenTurnOff());
        }
    }

    public int hitAmount_Max = 4;
    //private int guard_hitCurr = 0;
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
        beams.GetComponent<Animator>().SetBool("isFall", true);
        beams.GetComponent<Animator>().Play("beamFall");
        beams.GetComponent<AudioSource>().Play();
        bballgoal.GetComponent<Animator>().SetBool("isFall", true);
        bballgoal.GetComponent<Animator>().Play("goalFall");
        bballgoal.GetComponent<AudioSource>().clip = goalFall;
        bballgoal.GetComponent<AudioSource>().Play();
        BossAudio.clip = BossFightClips[12];
        BossAudio.Play();
    }

    IEnumerator WaitThenTurnOff()
    {
        yield return new WaitForSeconds(3.0f);
        tryAgainScreen.SetActive(false);
        yield return new WaitForSeconds(0f);
        Global.tryAgain = false;
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

                Global.guard_hitCurr++;
                print("HIT AMOUNT " + Global.guard_hitCurr);

                if (Global.guard_hitCurr >= hitAmount_Max)
                {
                    // You got hit too many times, it's over
                    StartCoroutine(BossDead());
                    Debug.Log("Yay, boss is dead");
                }
            }
        }
        if (meshhit.tag == "Bullet")
        {
            if (_animator.GetBool("Turned") == true)
            {
                //RUN PARTICLE SCRIPT HIT
                bodysparks.Play();
                BossAudio.clip = BossFightClips[5];
                BossAudio.Play();

            }
        }
        if (meshhit.tag == "Slime")
        {
            if (_animator.GetBool("Turned") == true)
            {
                BossAudio.clip = BossFightClips[7];
                BossAudio.Play();
            }
        }
        if (meshhit.tag == "Arm")
        {
            print("going back");
            Global.guard_hitCurr = 2;
            Global.tryAgain = true;
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