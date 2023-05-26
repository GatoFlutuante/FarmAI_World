using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
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
        taskBox.GetComponent<FarmScript>().haveTask = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plantacao")
            taskBox = other.gameObject;
            canTask = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Plantacao")
            taskBox = null;
            canTask = false;
    }
}
