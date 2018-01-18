using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneTimer : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(15.0f);
        SceneManager.LoadScene("SuperVolcano");
    }
}
