using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInSeveraltimes : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    // Some Variables
    public int hitAmount_Max = 10;
    private int hitAmount_Cur;

    void OnTriggerEnter(Collider col)
    {

        if (col.tag == "Bullet")
        {
            // Increment the hitAmount
            hitAmount_Cur++;

            if (hitAmount_Cur >= hitAmount_Max)
            {
                // You got hit too many times, it's over
                Debug.Log("Shit, I'm dead");
                //Destroy(gameObject);
            }
        }
    }
}
