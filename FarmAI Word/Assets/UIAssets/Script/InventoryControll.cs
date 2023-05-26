using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class InventoryControll : MonoBehaviour
{
    public int money;
    public Text moneyText;

    float integridade = 100f;
    public Slider integridadeSlider;
    GameObject[] farms;

    private void Update()
    {
        farms = GameObject.FindGameObjectsWithTag("Plantacao");
        moneyText.text = "$ " + money.ToString();
        integridadeSlider.value = integridade / 100;

        foreach (GameObject farm in farms)
        {
            FarmScript farmScript = farm.GetComponent<FarmScript>();
            if (farmScript.haveTask)
            {
                integridade -= Time.deltaTime;
            }
        }
    }
}
