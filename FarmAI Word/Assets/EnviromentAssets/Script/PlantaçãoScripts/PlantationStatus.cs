using UnityEngine;

public class PlantationStatus : MonoBehaviour
{
    [SerializeField]
    public float pHealth;
    [SerializeField]
    public float pWater;

    public GameObject barril;
    void Start()
    {
        pHealth = 100;
        pWater = 100;
    }
    private void Update()
    {
        PlantationController();
    }

    private void PlantationController()
    {
        UI_BarrilDeAguaTask b = barril.GetComponent<UI_BarrilDeAguaTask>();
        if (b.nivelDeAguaValue <= 0 && pWater >= 0)
        {
            pWater -= Time.deltaTime * 2;
        }
        else if (pWater < 100)
        {
            pWater += Time.deltaTime * 2;
        }
    }
}
