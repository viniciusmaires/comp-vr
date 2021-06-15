using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class guimanager2 : MonoBehaviour
{
    [Header("Buttons")]
    public GameObject startButton;
    public GameObject buttonPrefab;

    [Header("Objects Fields")]
    public GameObject[] numeros;
    public GameObject[] exemplos;
    public GameObject[] exemplos2;
    public GameObject[] exemplos3;
    public GameObject[] exemplos4;
    public GameObject robo;

    [Header("UI Objects")]
    public GameObject marker;
    private GameObject introText;
    public GameObject myTextPrefab;

    private GameObject numbers;
    private static GameObject Marker;

    private List<string> texts = new List<string>();
    private List<GameObject> objOnGUI = new List<GameObject>();
    //[SerializeField]
    public int paginas = -1;
    public int pag = -1;
    private int examplos = 0;
    private bool spawnButton = true;

    GameObject exampleButtom;

    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();

        texts.Add("\t Podemos converter os números binários \n\t em números decimais, precisamos apenas \n\t identificar os bits ativos (1) e somar os \n\t valores correspondentes.");
        texts.Add("\t Para realizar a conversão de decimal para binário, \n\t realiza-se a divisão sucessiva por 2. O resultado \n\t da conversão será dado pelo último quociente \n\t e o agrupamento dos restos de divisão. A leitura \n\t do resultado é feita do último quociente para o \n\t primeiro resto.");
        texts.Add("\t Na soma de dois números binários não é possível \n\t resultar um valor diferente de 0 ou 1, perceba que \n\t na soma dos bits 1 + 1 o resultado é 0 e “vai um”, \n\t resultando em dois bits 10.");
        texts.Add("\t Na subtração de dois números binários, assim \n\t como na adição, não é possível resultar um valor \n\t diferente de 0 ou 1, perceba que na subtração dos \n\t bits 0 - 1, o resultado é 1 e “vai um”.");
        texts.Add("\n\n\n\n\t\t\t\t\t\t\t\tEntenderam??");
        introText = (GameObject)Instantiate(myTextPrefab, this.transform);
        introText.transform.localPosition = new Vector3(60f, 80f, 0f);
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
        introText.transform.localPosition = new Vector3(24f, 145f, 14f);
        introText.GetComponent<Text>().text = " \n\t Os números binários formam um sistema \n\t matemático usado por computadores para \n\t criar informações. Ele é composto por uma \n\t base de apenas dois algarismos: 0 e 1. \n\t Por tanto, são formadas sequências e, a \n\t partir delas, são formadas letras, palavras, \n\t textos, cálculos.";

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

        pag = 0;
        paginas++;
        paginas = Mathf.Clamp(paginas, -1, 5);

        if (paginas == 5)
        {
            SceneManager.LoadScene("FaseOneScene", LoadSceneMode.Single);
            return;
        }
        if (paginas == 4)
        {
            audio.Play();
        }


        Destroy(numbers);

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
                

                exampleButtom = (GameObject)Instantiate(buttonPrefab, this.transform);
                exampleButtom.transform.localPosition = new Vector3(2.6f, -170f, 0f);
                exampleButtom.transform.GetChild(0).GetComponent<Text>().text = "Exemplo";
                exampleButtom.GetComponent<Button>().onClick.AddListener(ShowAnimation);
                objOnGUI.Add(exampleButtom);
            }
        }

        if(paginas == 0 || paginas == 1) 
        { 
        numbers = (GameObject)Instantiate(numeros[paginas], this.transform);
        numbers.transform.localPosition = new Vector3(-70f, -70f, 0f);
        numbers.transform.localScale = new Vector3(17f, 27f, 47f);
        numbers.transform.eulerAngles = new Vector3(0f, 90f,0f);

        introText.GetComponent<Text>().text = texts[paginas];
        }

        if (paginas == 2 || paginas == 3)
        {
            numbers = (GameObject)Instantiate(numeros[paginas], this.transform);
            numbers.transform.localPosition = new Vector3(-10f, -119f, -7.5f);
            numbers.transform.localScale = new Vector3(22f, 36f, 63f);
            numbers.transform.eulerAngles = new Vector3(0f, 90f, 0f);

            introText.GetComponent<Text>().text = texts[paginas];
        }

        if (paginas == 4)
        {
            introText.GetComponent<Text>().text = texts[paginas];
            Destroy(exampleButtom);
        }

        examplos = 0;



        if (Marker != null)
        {
            Destroy(Marker);
        }
        pag = 0;

    }

    public void BackAction()
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
        Destroy(numbers);

        if (paginas == 0 || paginas == 1)
        {
            numbers = (GameObject)Instantiate(numeros[paginas], this.transform);
            numbers.transform.localPosition = new Vector3(-70f, -70f, 0f);
            numbers.transform.localScale = new Vector3(17f, 27f, 47f);
            numbers.transform.eulerAngles = new Vector3(0f, 90f, 0f);

            introText.GetComponent<Text>().text = texts[paginas];
        }

        if (paginas == 2 || paginas == 3)
        {
            numbers = (GameObject)Instantiate(numeros[paginas], this.transform);
            numbers.transform.localPosition = new Vector3(-10f, -119f, -7.5f);
            numbers.transform.localScale = new Vector3(22f, 36f, 63f);
            numbers.transform.eulerAngles = new Vector3(0f, 90f, 0f);

            introText.GetComponent<Text>().text = texts[paginas];
        }
        if(paginas == 4)
        {
            introText.GetComponent<Text>().text = texts[paginas];
        }
    }
    
    public void ShowAnimation()
    {

        if (paginas == 0)
        {

            Destroy(numbers);
            numbers = (GameObject)Instantiate(exemplos[pag], this.transform);
            numbers.transform.localPosition = new Vector3(-70f, -70f, 0f);
            numbers.transform.localScale = new Vector3(17f, 27f, 47f);
            numbers.transform.eulerAngles = new Vector3(0f, 90f, 0f);
            pag++;
            pag = Mathf.Clamp(pag, 0, 1);
        }

        if (paginas == 1)
        {
            Destroy(numbers);
            numbers = (GameObject)Instantiate(exemplos2[pag], this.transform);
            numbers.transform.localPosition = new Vector3(-70f, -70f, 0f);
            numbers.transform.localScale = new Vector3(17f, 27f, 47f);
            numbers.transform.eulerAngles = new Vector3(0f, 90f, 0f);
            pag++;
            pag = Mathf.Clamp(pag, 0, 1);

        }
        if (paginas == 2)
        {
            Destroy(numbers);
            numbers = (GameObject)Instantiate(exemplos3[pag], this.transform);
            numbers.transform.localPosition = new Vector3(-10f, -119f, -7.5f);
            numbers.transform.localScale = new Vector3(22f, 36f, 63f);
            numbers.transform.eulerAngles = new Vector3(0f, 90f, 0f);
            pag++;
            pag = Mathf.Clamp(pag, 0, 1);

        }
        if (paginas == 3)
        {
            Destroy(numbers);
            numbers = (GameObject)Instantiate(exemplos4[pag], this.transform);
            numbers.transform.localPosition = new Vector3(-10f, -119f, -7.5f);
            numbers.transform.localScale = new Vector3(22f, 36f, 63f);
            numbers.transform.eulerAngles = new Vector3(0f, 90f, 0f);
            pag++;
            pag = Mathf.Clamp(pag, 0, 1);

        }

    }
}
