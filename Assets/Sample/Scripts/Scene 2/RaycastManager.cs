using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager : MonoBehaviour
{
    public GameObject AndPort;
    public GameObject OrPort;
    private float actionDistance = 0.5f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, actionDistance))
            {
                if (hit.collider.gameObject == AndPort)
                {
                    AndPort.GetComponent<AndPortButtonOption>().SendToPosition();
                }
                if (hit.collider.gameObject == OrPort)
                {
                    OrPort.GetComponent<OrPortButtonOption>().SendToPosition();
                }
            }
        }
        
    }
}
