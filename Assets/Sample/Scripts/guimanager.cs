using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class guimanager : MonoBehaviour
{
    [Header("Buttons")]
    public GameObject startButton;
    public GameObject buttonPrefab;

    [Header("Objects Fields")]
    public GameObject[] portas;
    public GameObject[] tabelas;
    public GameObject robo;

    [Header("UI Objects")]
    public GameObject marker;
    private GameObject introText;
    public GameObject myTextPrefab;

    private GameObject logicPort;
    private GameObject logicTabel;
    private static GameObject Marker;

    private List<string> texts = new List<string>();
    private List<GameObject> objOnGUI = new List<GameObject>();
    //[SerializeField]
    private int paginas = -1;
    private int examplos = 0;
    private bool spawnButton = true;


    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        
        texts.Add("\t Esta é a porta lógica E, ela obedece\n\t a seguinte tabela da verdade. Clique\n\t em Exemplo para ver as entradas\n\t e saídas na porta lógica");
        texts.Add("\t Esta é a porta lógica OU, ela obedece\n\t a seguinte tabela da verdade. Clique\n\t em Exemplo para ver as entradas\n\t e saídas na porta lógica");
        texts.Add("\t Sabia que podemos combinar as\n\t portas lógicas para formar circuitos\n\t\t maiores e complexos?");
        texts.Add("\n\t Veja este outro exemplo de uma\n\t combinação");
        texts.Add("\n\n\n\n\t\t\t\t\t\t\t\tEntenderam??");
        introText = (GameObject)Instantiate(myTextPrefab, this.transform);
        introText.transform.localPosition = new Vector3(23f, 100f, 0f);
        introText.GetComponent<Text>().text = " \n\t Olá, você tem o superpoder de entrar\n\t em computadores e corrigir os\n\t circuitos computacionais";


    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AcaoBotao()
    {
        Intro();
        robo.GetComponent<Animator>().SetBool("Andar", true);
        

    }

    public void Intro()
    {
        GameObject botaoBack;
        GameObject botaoNext;

        Destroy(introText);
        introText = (GameObject)Instantiate(myTextPrefab, this.transform);
        introText.transform.localPosition = new Vector3(23f, 100f, 0f);
        introText.GetComponent<Text>().text = " \n\t Portas Lógicas são dispositivos que\n\t são fundamentais para a criação de\n\t circuitos computacionais, elas operam\n\t com sinais binários de entrada e saída";

        botaoBack = (GameObject)Instantiate(buttonPrefab, this.transform);
        botaoBack.transform.localPosition = new Vector3(-154f, -90f, 0f);
        botaoBack.transform.GetChild(0).GetComponent<Text>().text = "back";
        botaoBack.GetComponent<Button>().onClick.AddListener(BackAction);
        objOnGUI.Add(botaoBack);

        botaoNext = (GameObject)Instantiate(buttonPrefab, this.transform);
        botaoNext.transform.localPosition = new Vector3(154f, -90f, 0f);
        botaoNext.transform.GetChild(0).GetComponent<Text>().text = "next";
        botaoNext.GetComponent<Button>().onClick.AddListener(NextAction);
        objOnGUI.Add(botaoNext);



        Destroy(startButton);
    }

    public void NextAction()
    {

        paginas++;
        paginas = Mathf.Clamp(paginas, -1, 5);

        if (paginas == 5)
        {
            SceneManager.LoadScene("FaseOneScene", LoadSceneMode.Single);
            return;
        }
        if(paginas == 4)
        {
            audio.Play();
        }
        

        Destroy(logicTabel);
        Destroy(logicPort);

        if (paginas == 0)
        {
            foreach (var obj in objOnGUI)
            {
                if (obj.transform.GetChild(0).GetComponent<Text>().text == "Exemplo")
                {
                    spawnButton = false;
                }
            }

            if (spawnButton == true)
            {
                GameObject exampleButtom;

                exampleButtom = (GameObject)Instantiate(buttonPrefab, this.transform);
                exampleButtom.transform.localPosition = new Vector3(2.6f, -170f, 0f);
                exampleButtom.transform.GetChild(0).GetComponent<Text>().text = "Exemplo";
                exampleButtom.GetComponent<Button>().onClick.AddListener(ShowAnimation);
                objOnGUI.Add(exampleButtom);
            }
        }

        logicPort = (GameObject)Instantiate(portas[paginas], this.transform);
        logicPort.transform.localPosition = new Vector3(-160f, 1f, 0f);
        logicPort.transform.localScale = new Vector3(3500f, 6500f, 7000f);
        logicPort.transform.eulerAngles = new Vector3(0f, 0f, 90f);

        introText.GetComponent<Text>().text = texts[paginas];

        logicTabel = (GameObject)Instantiate(tabelas[paginas], this.transform);
        logicTabel.transform.localPosition = new Vector3(180f, -223f, 0f);
        logicTabel.transform.localScale = new Vector3(100f, 120f, 120f);
        logicTabel.transform.eulerAngles = new Vector3(0f, 90f, 0f);

        examplos = 0;

        if (Marker != null)
        {
            Destroy(Marker);
        }

    }

    public  void BackAction()
    {

        paginas--;
        paginas = Mathf.Clamp(paginas, -1, 4);

        if (paginas < 0)
        {
            foreach (var guiElement in objOnGUI)
            {
                Destroy(guiElement);

            }
            Destroy(introText);
           

            objOnGUI.Clear();
            Intro();
        }
        Destroy(logicTabel);
        Destroy(logicPort);

        logicPort = (GameObject)Instantiate(portas[paginas], this.transform);
        logicPort.transform.localPosition = new Vector3(-160f, 1f, 0f);
        logicPort.transform.localScale = new Vector3(3500f, 7000f, 7000f);
        logicPort.transform.eulerAngles = new Vector3(0f, 0f, 90f);

        logicTabel = (GameObject)Instantiate(tabelas[paginas], this.transform);
        logicTabel.transform.localPosition = new Vector3(180f, -223f, 0f);
        logicTabel.transform.localScale = new Vector3(100f, 120f, 120f);
        logicTabel.transform.eulerAngles = new Vector3(0f, 90f, 0f);

        introText.GetComponent<Text>().text = texts[paginas];

    }

    public void ShowAnimation()
    {
        
     
        if (paginas == 0)   //E
        {
            if (Marker == null)
            {
                Marker = (GameObject)Instantiate(marker, this.transform);
                Marker.GetComponent<RectTransform>().sizeDelta = new Vector2(1363.21f, 192.87f);
            }

            Transform Canvas = logicPort.transform.GetChild(0);
            if (examplos == 0)
            {
                Canvas.GetChild(0).GetComponent<Text>().text = "0";
                Canvas.GetChild(1).GetComponent<Text>().text = "0";
                Marker.GetComponent<RectTransform>().localPosition = new Vector3(180.7f, 10.62f, -4.3f);
            }

            else if (examplos == 1)
            {
                //Destroy(Marker);
                Canvas.GetChild(0).GetComponent<Text>().text = "0";
                Canvas.GetChild(1).GetComponent<Text>().text = "1";
                Marker.GetComponent<RectTransform>().localPosition = new Vector3(180.7f, -8f, -4.3f);
            }

            else if (examplos == 2)
            {
                Canvas.GetChild(0).GetComponent<Text>().text = "1";
                Canvas.GetChild(1).GetComponent<Text>().text = "0";
                Marker.GetComponent<RectTransform>().localPosition = new Vector3(180.7f, -27f, -4.3f);
            }
            else if (examplos == 3)
            {
                Canvas.GetChild(0).GetComponent<Text>().text = "1";
                Canvas.GetChild(1).GetComponent<Text>().text = "1";
                Canvas.GetChild(2).GetComponent<Text>().text = "1";
                Marker.GetComponent<RectTransform>().localPosition = new Vector3(180.7f, -45.62f, -4.3f);
            }

           
            logicPort.GetComponent<Animator>().SetBool("Animate", true);
            //logicPort.GetComponent<Animator>().Play("_00", 0);
            examplos ++;
        }

        if(paginas == 1)// OU
        {

            if (Marker == null)
            {
                Marker = (GameObject)Instantiate(marker, this.transform);
                Marker.GetComponent<RectTransform>().sizeDelta = new Vector2(1363.21f, 192.87f);
            }

            Transform Canvas = logicPort.transform.GetChild(0);
            if (examplos == 0)
            {
                Canvas.GetChild(0).GetComponent<Text>().text = "0";
                Canvas.GetChild(1).GetComponent<Text>().text = "0";
                Marker.GetComponent<RectTransform>().localPosition = new Vector3(180.7f, 10.62f, -4.3f);
            }

            else if (examplos == 1)
            {
                Canvas.GetChild(0).GetComponent<Text>().text = "0";
                Canvas.GetChild(1).GetComponent<Text>().text = "1";
                Canvas.GetChild(2).GetComponent<Text>().text = "1";
                Marker.GetComponent<RectTransform>().localPosition = new Vector3(180.7f, -8f, -4.3f);
            }

            else if (examplos == 2)
            {
                Canvas.GetChild(0).GetComponent<Text>().text = "1";
                Canvas.GetChild(1).GetComponent<Text>().text = "0";
                Canvas.GetChild(2).GetComponent<Text>().text = "1";
                Marker.GetComponent<RectTransform>().localPosition = new Vector3(180.7f, -27f, -4.3f);
            }
            else if (examplos == 3)
            {
                Canvas.GetChild(0).GetComponent<Text>().text = "1";
                Canvas.GetChild(1).GetComponent<Text>().text = "1";
                Canvas.GetChild(2).GetComponent<Text>().text = "1";
                Marker.GetComponent<RectTransform>().localPosition = new Vector3(180.7f, -45.62f, -4.3f);
            }

            logicPort.GetComponent<Animator>().SetBool("animate2", true);
            //logicPort.GetComponent<Animator>().Play("_00", 0);
            examplos++;
        }
        if (paginas == 2)// Combinação
        {
            Debug.Log(logicPort.name);
            Transform Canvas = logicPort.transform.GetChild(0);

            if (examplos == 0)
            {
                Canvas.GetChild(0).GetComponent<Text>().text = "0";
                Canvas.GetChild(1).GetComponent<Text>().text = "0";
                Canvas.GetChild(2).GetComponent<Text>().text = "0";
                Canvas.GetChild(3).GetComponent<Text>().text = "0";
                Canvas.GetChild(4).GetComponent<Text>().text = "0";
            }

            else if (examplos == 1)
            {
                Canvas.GetChild(0).GetComponent<Text>().text = "1";
                Canvas.GetChild(1).GetComponent<Text>().text = "1";
                Canvas.GetChild(2).GetComponent<Text>().text = "1";
                Canvas.GetChild(3).GetComponent<Text>().text = "0";
                Canvas.GetChild(4).GetComponent<Text>().text = "1";
            }

            else if (examplos == 2)
            {
                Canvas.GetChild(0).GetComponent<Text>().text = "0";
                Canvas.GetChild(1).GetComponent<Text>().text = "0";
                Canvas.GetChild(2).GetComponent<Text>().text = "0";
                Canvas.GetChild(3).GetComponent<Text>().text = "1";
                Canvas.GetChild(4).GetComponent<Text>().text = "0";
            }
            else if (examplos == 3)
            {
                Canvas.GetChild(0).GetComponent<Text>().text = "1";
                Canvas.GetChild(1).GetComponent<Text>().text = "1";
                Canvas.GetChild(2).GetComponent<Text>().text = "0";
                Canvas.GetChild(3).GetComponent<Text>().text = "1";
                Canvas.GetChild(4).GetComponent<Text>().text = "1";
            }

            logicPort.GetComponent<Animator>().SetBool("animate3", true);
            
            examplos++;
        }

        if (paginas == 3)// Combinação 2
        {
            Debug.Log(logicPort.name);
            Transform Canvas = logicPort.transform.GetChild(0);

            if (examplos == 0)
            {
                Canvas.GetChild(0).GetComponent<Text>().text = "0";
                Canvas.GetChild(1).GetComponent<Text>().text = "0";
                Canvas.GetChild(2).GetComponent<Text>().text = "0";
                Canvas.GetChild(3).GetComponent<Text>().text = "0";
                Canvas.GetChild(4).GetComponent<Text>().text = "0";
            }

            else if (examplos == 1)
            {
                Canvas.GetChild(0).GetComponent<Text>().text = "1";
                Canvas.GetChild(1).GetComponent<Text>().text = "1";
                Canvas.GetChild(2).GetComponent<Text>().text = "1";
                Canvas.GetChild(3).GetComponent<Text>().text = "0";
                Canvas.GetChild(4).GetComponent<Text>().text = "1";
            }

            else if (examplos == 2)
            {
                Canvas.GetChild(0).GetComponent<Text>().text = "0";
                Canvas.GetChild(1).GetComponent<Text>().text = "0";
                Canvas.GetChild(2).GetComponent<Text>().text = "0";
                Canvas.GetChild(3).GetComponent<Text>().text = "1";
                Canvas.GetChild(4).GetComponent<Text>().text = "0";
            }
            else if (examplos == 3)
            {
                Canvas.GetChild(0).GetComponent<Text>().text = "1";
                Canvas.GetChild(1).GetComponent<Text>().text = "1";
                Canvas.GetChild(2).GetComponent<Text>().text = "0";
                Canvas.GetChild(3).GetComponent<Text>().text = "1";
                Canvas.GetChild(4).GetComponent<Text>().text = "1";
            }

            logicPort.GetComponent<Animator>().SetBool("condi", true);

            examplos++;
        }

    }
}
