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
    public GameObject lowWaterLevelAlert;
    FXController fx;

    private void Start()
    {
        fx = GetComponent<FXController>();
    }

    private void Update()
    {
        BarrilDeAguaController();
    }

    private void BarrilDeAguaController()
    {
        nivelDeAgua.value = nivelDeAguaValue / 100;

        if (nivelDeAguaValue > 0)
        {
            nivelDeAguaValue -= Time.deltaTime * 2;
            lowWaterLevelAlert.SetActive(false);
        }
        else
            lowWaterLevelAlert.SetActive(true);
    }

    public void StartTask()
    {
        if(nivelDeAguaValue < 100)
        {
            nivelDeAguaValue += Time.deltaTime * 10;
            fx.StartWaterSound();
            fx.StartWaterVFX();
        }
    }
}
