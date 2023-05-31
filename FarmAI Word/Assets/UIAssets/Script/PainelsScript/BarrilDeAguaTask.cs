using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public interface ITask
{
    void StartTask();
}
public class BarrilDeAguaTask : MonoBehaviour, ITask
{
    public Slider nivelDeAgua;
    [SerializeField]
    public float nivelDeAguaValue;

    private void Start()
    {
        nivelDeAguaValue = 100;
    }

    private void Update()
    {
        nivelDeAgua.value = nivelDeAguaValue / 100;
        if (nivelDeAguaValue >= 0)
        {
            nivelDeAguaValue -= Time.deltaTime;
        }
    }
    public void StartTask()
    {
        if (nivelDeAguaValue <= 100)
        {
            nivelDeAguaValue += Time.deltaTime * 10;
        }
    }
}
