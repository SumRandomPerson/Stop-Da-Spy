using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool opened = false;
    void OnTriggerEnter(Collider other)
    {
        if(opened == false)
        {
            opened = true;
            transform.Translate(0f,-0.2f,0);
            transform.Rotate(90f,0f,0f);
        }
    }
}
