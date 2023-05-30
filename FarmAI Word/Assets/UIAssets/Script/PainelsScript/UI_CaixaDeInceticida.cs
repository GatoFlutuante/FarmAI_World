using UnityEngine;
using UnityEngine.UI;

public class UI_CaixaDeInceticida : MonoBehaviour
{
    public Text incecticideCountText;
    public int stockCount;

    private void Update()
    {
        incecticideCountText.text = stockCount.ToString();
    }
}
