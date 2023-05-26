using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmScript : MonoBehaviour
{
    public bool haveTask;
    public GameObject blip;

    private void Update()
    {
        blip.SetActive(haveTask);
        blip.transform.Rotate(0,1,0);
    }
}
