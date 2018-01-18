using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterElec : MonoBehaviour
{

    public Transform crosshair;
    public GameObject projectile;
    private SteamVR_TrackedController controller;
    public float shootingRate = 2f;
    public float shootCooldown;

    // Use this for initialization
    void Start()
    {
        shootCooldown = shootingRate;
        controller = GetComponent<SteamVR_TrackedController>();
        controller.TriggerClicked += Shoot;
    }

    // Update is called once per frame
    void Update()
    {
        if (shootCooldown > 0f)
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    void Shoot(object sender, ClickedEventArgs e)
    {
        if (shootCooldown < Time.deltaTime)
        {
            if (projectile)
            {
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
}