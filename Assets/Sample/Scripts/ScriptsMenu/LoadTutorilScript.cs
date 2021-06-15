using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTutorilScript : MonoBehaviour
{
    
    public void LoadByIndex(int sceneIndex)
    {
       
        SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
        return;
    }

}
