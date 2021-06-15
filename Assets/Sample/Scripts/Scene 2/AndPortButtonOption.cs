using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndPortButtonOption : MonoBehaviour
{
    public Transform parent;
    public GameObject logicPort;
    public Transform target;
    public GameController mainControler;

    private GameObject logicPortOnScreen;

    public void SendToPosition()
    {
        logicPortOnScreen = (GameObject)Instantiate(logicPort, parent);
        logicPortOnScreen.transform.position = new Vector3(.22f, 1.23f, -5.74f);
        logicPortOnScreen.transform.localScale = new Vector3(2.7f, 4.7f, 4.7f);
        logicPortOnScreen.GetComponent<AndPortManager>().PointToMove = target;
        logicPortOnScreen.name = logicPort.name;
        mainControler.GivenAnswer = logicPortOnScreen;

    }
}
