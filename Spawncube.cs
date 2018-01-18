/*using UnityEngine;

public class Spawncube : MonoBehaviour
{

    public Transform Spawnpoint1;
    public Rigidbody Prefab;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boss")
        {
            Rigidbody RigidPrefab;
            RigidPrefab = Instantiate(Prefab, Spawnpoint1.position, Spawnpoint1.rotation) as Rigidbody;
        }
    }
}*/