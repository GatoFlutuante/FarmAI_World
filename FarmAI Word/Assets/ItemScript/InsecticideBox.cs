using UnityEngine;

public class InsecticideBox : MonoBehaviour
{
    public GameObject insecticidePrefab; // Prefab do inseticida
    public UI_CaixaDeInceticida ui;

    public GameObject GetInsecticideItem()
    {
        if(ui.stockCount > 0)
        {
            // Instancia o inseticida a partir do prefab
            GameObject insecticideItem = Instantiate(insecticidePrefab, transform.position, Quaternion.identity);

            ui.stockCount--;
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
        ui.stockCount++;
    }
}
