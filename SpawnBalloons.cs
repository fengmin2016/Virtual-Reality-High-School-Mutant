using UnityEngine;

public class SpawnBalloons : MonoBehaviour
{

    public Transform Spawnpoint;
    public Rigidbody Prefab;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BackTrigger")
        {
            Rigidbody RigidPrefab;
            RigidPrefab = Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation) as Rigidbody;
        }
    }
}

