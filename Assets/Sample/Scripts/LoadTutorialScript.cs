using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTutorialScript : MonoBehaviour
{
    
    public void LoadByIndex(int sceneIndex)
    {
        
        SceneManager.LoadScene("VideoScene", LoadSceneMode.Single);
        return;
    }
}
