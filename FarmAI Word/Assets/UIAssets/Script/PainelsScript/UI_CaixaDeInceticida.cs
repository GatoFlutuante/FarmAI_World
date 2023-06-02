using UnityEngine;
using UnityEngine.UI;

public class UI_CaixaDeInceticida : MonoBehaviour
{
    public static int stockCount;

    public int currentStockCount;
    public Text incecticideCountText;

    private void Start()
    {
        //currentStockCount = stockCount;
    }
    private void Update()
    {
        incecticideCountText.text = currentStockCount.ToString();
        //stockCount = currentStockCount;
    }
}
