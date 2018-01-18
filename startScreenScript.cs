using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startScreenScript : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Arm")
        {
            SceneManager.LoadScene("SuperVolcano");
        }
    }
}
