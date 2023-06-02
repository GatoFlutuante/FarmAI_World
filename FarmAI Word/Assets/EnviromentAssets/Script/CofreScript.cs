using TMPro;
using UnityEngine;

public class CofreScript : MonoBehaviour
{
    public static int money = 3000;
    public int currentMoney;
    public GameObject[] farms;
    public TextMeshProUGUI moneyText;

    private void Start()
    {
        PushMoney();
    }
    private void Update()
    {
        moneyText.text = "$ " + currentMoney.ToString();
    }
    public void PushMoney()
    {
        currentMoney = money;
    }
    public void GetMoney()
    {
        money = currentMoney + GenerateSalary();
    }
    public int GenerateSalary()
    {
        farms = GameObject.FindGameObjectsWithTag("Farm");
        int totalSalary = 0;
        foreach (GameObject f in farms)
        {
            PlantationStatus st = f.GetComponent<PlantationStatus>();
            if(st.pHealth > 0 && st.pHealth < 50)
            {
                totalSalary += 100;
            }
            else if(st.pHealth > 50 && st.pHealth < 80)
            {
                totalSalary += 500;
            }
            else if(st.pHealth > 80)
            {
                totalSalary += 1000;
            }
        }
        return totalSalary;
    }

    public void PayItem(int value)
    {
        currentMoney -= value;
    }
}
