using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTutorialScript2 : MonoBehaviour
{

    public void LoadByIndex(int sceneIndex)
    {

        SceneManager.LoadScene("VideoScene2", LoadSceneMode.Single);
        return;
    }
}