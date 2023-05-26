using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FarmController : MonoBehaviour
{
    public float timeRateTask;
    public float timeDelayTask; 
    public GameObject[] farms;

    void Update()
    {
        //Teste1();
        farms = GameObject.FindGameObjectsWithTag("Plantacao");
        GenerateTask();
    }

    private void GenerateTask()
    {
        if (Time.time >= timeDelayTask)
        {
            if (SorteiaObjeto() != null)
            {
                SorteiaObjeto().GetComponent<FarmScript>().haveTask = true;
                print("Tem Task");
            }
            else
                print("Não Tem Task");
            timeDelayTask = Time.time + timeRateTask;
        }
    }

    private GameObject SorteiaObjeto()
    {
        List<GameObject> availableObjects = new List<GameObject>();

        foreach (GameObject farm in farms)
        {
            FarmScript farmScript = farm.GetComponent<FarmScript>();
            if (farmScript != null && !farmScript.haveTask)
            {
                availableObjects.Add(farm);
            }
        }

        if (availableObjects.Count == 0)
        {
            //Debug.LogWarning("Nenhum objeto disponível com 'haveTask' definido como false.");
            return null;
        }

        int randomIndex = Random.Range(0, availableObjects.Count);
        GameObject selectedObject = availableObjects[randomIndex];
        return selectedObject;
    }


    /*private void Teste1()
    {
        Timer -= Time.deltaTime;
        if (Timer < 0)
        {
            if (FarmNumb == 1)
            {
                Task1 = true;
                Debug.Log("Task1");
            }
            else if (FarmNumb == 2)
            {
                Task2 = true;
                Debug.Log("Task2");
            }
            else if (FarmNumb == 3)
            {
                Task3 = true;
                Debug.Log("Task3");
            }
            else if (FarmNumb == 4)
            {
                Task4 = true;
                Debug.Log("Task4");
            }

            Debug.Log("Fazenda" + FarmNumb);
            FarmNumb = Random.Range(1, 4);
            Timer = Random.Range(5, 10);

        }
    }*/
}
