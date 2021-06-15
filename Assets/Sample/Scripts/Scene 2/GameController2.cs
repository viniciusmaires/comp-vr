using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController2 : MonoBehaviour
{
    
    public GameObject[] RightAnswer;
    public Queue<GameObject> Answers = new Queue<GameObject>();

    public Transform Canvas;

    //[HideInInspector]
    public GameObject GivenAnswer;

    public GameObject myTextPrefab;
    public GameObject buttonPrefab;

    public GameObject[] combinations;
    public GameObject objInScene;
    Vector3 objInScenePos;

    public Vector3 objInSceneScale { get; private set; }

    private int i;

    GameObject introText;

    private int pontuacao;

    private List<string> texts = new List<string>();

    public void Start()
    {
        if (GameObject.Find("prefabDesafio")){
            objInScene = GameObject.Find("prefabDesafio");
        }
        if (GameObject.Find("desafioSoma (1)"))
        {
            objInScene = GameObject.Find("desafioSoma (1)");
        }
        if (GameObject.Find("desafioSub (2)"))
        {
            objInScene = GameObject.Find("desafioSub (2)");
        }
        objInScenePos = objInScene.transform.position;
        objInSceneScale = objInScene.transform.localScale;
        
        for (int i = 0; i < RightAnswer.Length; i++)
        {
            Answers.Enqueue(RightAnswer[i]);
        }

 

        introText = (GameObject)Instantiate(myTextPrefab, Canvas);
        introText.transform.localPosition = new Vector3(-230f, 250f, 0f);
        introText.GetComponent<Text>().text = "Selecione uma das duas opções que complete \ncorretamente a operação apresentada abaixo.";

    }

    public void CheckAnswer()
    {
            
        if (Answers.Peek().name == GivenAnswer.name)
        {
            parametros.pontuacao += 10;
            introText = (GameObject)Instantiate(myTextPrefab, Canvas);
            introText.transform.localPosition = new Vector3(-100f, 180f, 0f);
            introText.GetComponent<Text>().text = "Resposta Certa!!! Parabéns" + "\nSua Pontuação: " + parametros.pontuacao.ToString() + " Pontos";
        }
        else
        {
            parametros.pontuacao += 5;
            introText = (GameObject)Instantiate(myTextPrefab, Canvas);
            introText.transform.localPosition = new Vector3(-100f, 180f, 0f);
            introText.GetComponent<Text>().text = "Resposta Errada :(" + "\nSua Pontuação: " + parametros.pontuacao.ToString() + " Pontos";
        }
    }

    public void Next()

    {
        
        int sceneIndex = SceneManager.GetActiveScene().buildIndex; //pega o index da cena
        if (GivenAnswer != null)
        {
            
            i++;
            Answers.Dequeue();

            
            
            if(Answers.Count == 0 && sceneIndex == 9)
            {
                SceneManager.LoadScene("fase1_2", LoadSceneMode.Single);
                return;
            }else if(Answers.Count == 0 && sceneIndex == 10)
            {
                SceneManager.LoadScene("fase1_3", LoadSceneMode.Single);
                return;
            }
            else if (Answers.Count == 0 && sceneIndex == 11)
            {
                SceneManager.LoadScene("Menu", LoadSceneMode.Single);
                return;
            }

            print("What is objInScene: " + objInScene);
            Destroy(objInScene);
            print("Destroyed objInScene: " + objInScene);
            Destroy(GivenAnswer);
            Destroy(introText);

            //objInScene = Instantiate(combinations[i], objInScenePos,Quaternion.identity);
            //objInScene.transform.localScale = objInSceneScale;
            //objInScene.transform.localEulerAngles = new Vector3(0.269f, 1.044f, -4.89f);
            //objInScene.transform.eulerAngles = new Vector3(0f, -90f, 0f);
            //objInScene.transform.localScale = new Vector3(0.06952316f, 0.06952316f, 0.06952316f);
            //objInScene.SetActive(true);


        }
    }
}
