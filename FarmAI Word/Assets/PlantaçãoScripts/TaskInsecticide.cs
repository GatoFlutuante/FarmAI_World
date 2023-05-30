using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TaskInsecticide : MonoBehaviour, ITask
{
    public GameObject alert;
    public float BugTimer;
    public bool Infestation;
    public PlantationStatus Integrity;
    public float Health;
    private void Start()
    {
        BugTimer = Random.Range(10f, 30f);
        alert.SetActive(false);
        Integrity = GetComponent<PlantationStatus>();
        Health = Integrity.pHealth;
    }
    private void Update()
    {
        BugTimer -= Time.deltaTime;
        if(BugTimer <= 0)
        {
            Infestation = true;
            alert.SetActive(true);
            Health -= Time.deltaTime * 2;
        }
    }
    public void StartTask()
    {
        
    }
}
