using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour

{
    public bool HasTimeEnded;
    public float levelTimer = 10;
    public int Points;
    public float TimerPoints = 60;
    public Text pointText;
    public GameObject PntA;
    public GameObject PntB;
    public GameObject PntC;
    public GameObject PntD;

    public TimerSystem timerSystem;
    public GameObject[] plantacoes;
    void Start()
    {
        timerSystem = GetComponent<TimerSystem>();
    }

    void Update()
    {
        pointText.text = Points.ToString();
        if (timerSystem.timerIsRunning == false)
        {
            ReceiveCoins();
        }
    }

    private void ReceiveCoins()
    {
        plantacoes = GameObject.FindGameObjectsWithTag("Farm");
        foreach (GameObject p in plantacoes)
        {
            PlantationStatus st = p.GetComponent<PlantationStatus>();
            if(st.pHealth > 0 && st.pHealth < 50)
            {
                print("5.000R$");
            }
            else if(st.pHealth > 50 && st.pHealth < 70)
            {
                print("10.000");
            }
            else if(st.pHealth > 70)
            {
                print("15.000");
            }
        }
    }

    void RafaScript()
    {
        TaskInsecticide TA = PntA.GetComponent<TaskInsecticide>();
        TaskInsecticide TB = PntB.GetComponent<TaskInsecticide>();
        TaskInsecticide TC = PntC.GetComponent<TaskInsecticide>();
        TaskInsecticide TD = PntD.GetComponent<TaskInsecticide>();
        levelTimer -= Time.deltaTime;
        TimerPoints -= Time.deltaTime;
        if (levelTimer <= 0)
        {
            HasTimeEnded = true;
        }
        if (TimerPoints <= 0)
        {
            Points = Points + 50;
            TimerPoints = 60;
        }
        pointText.text = "" + (Points + TA.InfestationPoints + TB.InfestationPoints);
    }
}
