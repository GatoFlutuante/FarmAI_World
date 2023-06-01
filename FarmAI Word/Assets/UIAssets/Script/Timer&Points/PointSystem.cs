using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour

{
    public bool HasTimeEnded;
    public float levelTimer = 300;
    public int Points;
    public float TimerPoints = 60;
    public Text pointText;
    public GameObject PntA;
    public GameObject PntB;
    public GameObject PntC;
    public GameObject PntD;
    void Start()
    {

    }


    void Update()
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
