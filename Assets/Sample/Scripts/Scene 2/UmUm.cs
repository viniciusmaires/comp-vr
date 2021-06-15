using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmUm : MonoBehaviour
{
    public Transform parent;
    public GameObject numero;
    public Transform target;
    public GameController2 mainControler;

    private GameObject BinarioOnScreen;

    public void SendToPosition()
    {
        BinarioOnScreen = (GameObject)Instantiate(numero, parent);
        BinarioOnScreen.transform.position = new Vector3(.22f, 1.23f, -5.74f);
        BinarioOnScreen.transform.eulerAngles = new Vector3(0f, 180f, 0f);
        BinarioOnScreen.transform.localScale = new Vector3(5.5f, 5.5f, 5.5f);
        BinarioOnScreen.GetComponent<UmUmManager>().PointToMove = target;
        BinarioOnScreen.name = numero.name;
        mainControler.GivenAnswer = BinarioOnScreen;
        BinarioOnScreen.SetActive(true);

    }
}
