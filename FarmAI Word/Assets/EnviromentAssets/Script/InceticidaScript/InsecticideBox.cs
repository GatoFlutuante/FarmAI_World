using UnityEngine;

public class InsecticideBox : MonoBehaviour
{
    public GameObject insecticidePrefab; // Prefab do inseticida
    public int itemValue;
    public UI_CaixaDeInceticida ui;

    public GameObject GetInsecticideItem()
    {
        if(ui.currentStockCount > 0)
        {
            // Instancia o inseticida a partir do prefab
            GameObject insecticideItem = Instantiate(insecticidePrefab, transform.position, Quaternion.identity);

            ui.currentStockCount--;
            // Retorna o inseticida instanciado
            return insecticideItem;
        }
        else
        {
            return null;
        }
    }
    public void PickInsecticideItem()
    {
        ui.currentStockCount++;
    }
}
