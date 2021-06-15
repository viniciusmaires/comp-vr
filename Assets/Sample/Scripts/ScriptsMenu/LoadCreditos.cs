using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCreditos : MonoBehaviour
{
    public void LoadByIndex1(int sceneIndex)
    {

        SceneManager.LoadScene("Creditos", LoadSceneMode.Single);
        return;
    }
}
