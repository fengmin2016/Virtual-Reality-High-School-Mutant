using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChangeMirror : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Arm" && mirrorGlobal.beenThere == false)
        {
            print("Away we go!");
            StartCoroutine(wait());
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("mirrorScene");
        mirrorGlobal.beenThere = true;
    }
}