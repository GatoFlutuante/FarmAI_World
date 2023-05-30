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

    GameObject player;
    private void Start()
    {
        ResetTimer();
        alert.SetActive(false);
        Integrity = GetComponent<PlantationStatus>();
        Health = Integrity.pHealth;
    }

    private void ResetTimer()
    {
        BugTimer = Random.Range(10f, 30f);
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
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void StartTask()
    {
        InventoryController inventory = player.GetComponent<InventoryController>();
        if (inventory.itemInHand != null)
        {
            GameObject item = inventory.itemInHand;
            if (item.tag == "IncetcidaTipo1")
            {
                ResetTimer();
                Infestation = false;
                Destroy(item);
            }       
            else
                print("Errado");
        }
        else
            print("Você Precisa do inceticida");
    }
}
