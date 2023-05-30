using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantationStatus : MonoBehaviour
{
    [SerializeField]
    public int pHealth;
    [SerializeField]
    public int pWater;
    void Start()
    {
        pHealth = 100;
        pWater = 100;
    }
}
