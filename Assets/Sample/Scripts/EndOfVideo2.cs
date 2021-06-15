using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfVideo2 : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(myTimer());
    }

    IEnumerator myTimer()
    {
        yield return new WaitForSeconds(5.6f);

        SceneManager.LoadScene("Tutorial2", LoadSceneMode.Single);
    }

}