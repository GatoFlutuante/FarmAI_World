using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryControll : MonoBehaviour
{
    public int money;
    public Text moneyText;

    float integridade = 100f;
    public Slider integridadeSlider;
    public Text integridadeText;

    private void Update()
    {
        moneyText.text = "$ " + money.ToString();
        integridadeSlider.value = integridade / 100;

        integridade -= 1 * Time.deltaTime;
        integridadeText.text = integridade.ToString() + "%";
    }
}
