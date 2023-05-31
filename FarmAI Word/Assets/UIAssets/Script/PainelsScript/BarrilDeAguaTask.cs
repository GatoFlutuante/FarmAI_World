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
    public float nivelDeAguaValue;

    private void Update()
    {
        nivelDeAgua.value = nivelDeAguaValue / 100;
    }
    public void StartTask()
    {
        nivelDeAguaValue += Time.deltaTime * 10;
    }
}
