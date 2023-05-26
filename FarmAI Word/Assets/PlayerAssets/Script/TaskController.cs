using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskController : MonoBehaviour
{
    GameObject taskBox;
    bool canTask;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   
        Cursor.visible = false;
    }
    private void Update()
    {
        if (canTask)
        {
            if(Input.GetButtonDown("Action"))
            {
                MakeTask();
            }
        }
    }

    private void MakeTask()
    {
        print("Ativar Task");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plantacao")
            canTask = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Plantacao")
            canTask = false;
    }
}
