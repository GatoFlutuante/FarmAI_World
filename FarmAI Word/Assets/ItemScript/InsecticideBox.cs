using UnityEngine;

public class InsecticideBox : MonoBehaviour
{
    public GameObject insecticidePrefab; // Prefab do inseticida

    public GameObject GetInsecticideItem()
    {
        // Instancia o inseticida a partir do prefab
        GameObject insecticideItem = Instantiate(insecticidePrefab, transform.position, Quaternion.identity);

        // Retorna o inseticida instanciado
        return insecticideItem;
    }
    InsecticideBox insecticideBox; // Referência ao componente InsecticideBox

    void Start()
    {
        insecticideBox = GetComponent<InsecticideBox>();
    }
}
