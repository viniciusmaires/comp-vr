using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfVideoTutorial : MonoBehaviour
{

    private void Start()
    {
        GetComponent<AudioSource>().Play();
        //audio.Play();
        StartCoroutine(myTimer());
    }

    IEnumerator myTimer()
    {
        yield return new WaitForSeconds(5.6f);

        SceneManager.LoadScene("Fase1", LoadSceneMode.Single);
    }

}
