using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    public GameObject taskBox;
    bool canTask;

    private void Update()
    {
        if (canTask)
        {
            if(Input.GetButton("Action"))
            {
                MakeTask();
            }
        }
    }

    private void MakeTask()
    {
        taskBox.GetComponent<ITask>().StartTask();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TaskArea" || other.gameObject.tag == "Farm")
            taskBox = other.gameObject;
            canTask = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "TaskArea" || other.gameObject.tag == "Farm")
            taskBox = null;
            canTask = false;
    }
}
