using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animaçoes : MonoBehaviour
{
    private Animator ControladorPorta;
    void Start()
    {
        ControladorPorta = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("0"))
        {
            ControladorPorta.SetInteger("cond", 0);
        }
        else if (Input.GetKeyDown("1"))
        {
            ControladorPorta.SetInteger("cond", 1);
        }
        else if (Input.GetKeyDown("2"))
        {
            ControladorPorta.SetInteger("cond", 2);
        }

    }
}
