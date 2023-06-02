using UnityEngine;

public class ShopController : MonoBehaviour
{
    public GameObject shopping;
    public bool inShop;

    //Sistema de compra
    CofreScript cofre;
    public GameObject[] insectsideBoxes;

    private void Update()
    {
        VisibilityController();
    }
    private void VisibilityController()
    {
        if (Input.GetButtonDown("Shop"))
            inShop = !inShop;

        shopping.SetActive(inShop);

        if (inShop)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void BuyItem(int boxIndex)
    {
        cofre = GameObject.FindGameObjectWithTag("Cofre").GetComponent<CofreScript>();
        if (cofre.currentMoney < insectsideBoxes[boxIndex].GetComponent<InsecticideBox>().itemValue)
        {
            print("Sem Dinheiro o suficiente");
        }
        else
        {
            insectsideBoxes[boxIndex].GetComponent<InsecticideBox>().PickInsecticideItem();
            cofre.PayItem(insectsideBoxes[boxIndex].GetComponent<InsecticideBox>().itemValue);
        }
    }
}