using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public Transform crosshair;
    public GameObject projectile;
    private SteamVR_TrackedController controller;
    public float shootingRate = 0.2f;
    public float shootCooldown;
    private BoxCollider bcol;

	// Use this for initialization
	void Start ()
    {
        shootCooldown = shootingRate;
        controller = GetComponent<SteamVR_TrackedController> ();
        controller.TriggerClicked += Shoot;
        controller.TriggerUnclicked += Release;
        bcol = GetComponent<BoxCollider>();
	}

    // Update is called once per frame
    void Update()
    {
        if (shootCooldown > 0f)
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    public void Shoot(object sender, ClickedEventArgs e)
    {
        if (shootCooldown < Time.deltaTime && mirrorGlobal.beenThere == true)
        {
            if (projectile)
            {
                bcol.enabled = false;
                GameObject newProjectile = Instantiate(projectile, crosshair.gameObject.transform.position, transform.rotation) as GameObject;
                newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * 20f, ForceMode.VelocityChange);

                //check if particle system exists
                if (newProjectile.GetComponentInChildren<ParticleSystem>())
                    newProjectile.GetComponentInChildren<ParticleSystem>().Play();
            }
            //Reset cooldown
            shootCooldown = shootingRate;
        }
    }	

    void Release(object sender, ClickedEventArgs e)
    {
        StartCoroutine(colWait());
    }

    IEnumerator colWait()
    {
        yield return new WaitForSeconds(0.5f);
        bcol.enabled = true;
    }
}
