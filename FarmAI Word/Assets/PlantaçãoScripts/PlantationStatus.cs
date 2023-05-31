using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantationStatus : MonoBehaviour
{
    [SerializeField]
    public float pHealth;
    [SerializeField]
    public float pWater;
    public TaskInsecticide HP;
    public BarrilDeAguaTask waterLvl;
    public float barrelWater;
    void Start()
    {
        pHealth = 100;
        pWater = 100;
        HP = GetComponent<TaskInsecticide>();
    }

    private void Update()
    {
        pHealth = HP.Health;
        barrelWater = waterLvl.nivelDeAguaValue;
        if (barrelWater <= 0)
        {
            pWater -= Time.deltaTime * 5;
            if(pWater <= 0)
            {
                pHealth -= Time.deltaTime * 7;
            }
        }
        
    }
}
