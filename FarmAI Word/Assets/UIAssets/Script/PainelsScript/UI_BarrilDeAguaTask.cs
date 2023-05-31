using UnityEngine;
using UnityEngine.UI;

public interface ITask
{
    void StartTask();
}
public class UI_BarrilDeAguaTask : MonoBehaviour, ITask
{
    public Slider nivelDeAgua;
    public float nivelDeAguaValue;

    private void Update()
    {
        BarrilDeAguaController();
    }

    private void BarrilDeAguaController()
    {
        nivelDeAgua.value = nivelDeAguaValue / 100;

        if (nivelDeAguaValue > 0)
            nivelDeAguaValue -= Time.deltaTime * 2;
    }

    public void StartTask()
    {
        if(nivelDeAguaValue < 100)
            nivelDeAguaValue += Time.deltaTime * 10;
    }
}
