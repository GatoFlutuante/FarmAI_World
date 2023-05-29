using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskController : MonoBehaviour
{
    public ITask script;

    public void FindTask()
    {
        script.StartTask();
    }
}
