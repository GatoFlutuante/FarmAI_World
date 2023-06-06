using UnityEngine;

public class ShopController : MonoBehaviour
{
    public GameObject shopping;
    public bool inShop;

    //Sistema de compra
    CofreScript cofre;
    public GameObject[] insectsideBoxes;
    FXController fx;

    private void Start()
    {
        fx = GetComponent<FXController>();
    }

    private void Update()
    {
        VisibilityController();
    }
    private void VisibilityController()
    {
        if (Input.GetButtonDown("Shop"))
        {
            if (!inShop)
            {
                fx.StartTakeItem(0);
            }
            inShop = !inShop;
        }

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
            insectsideBoxes[boxIndex].GetComponent<InsecticideBox>().BuyInsecticideItem();
            fx.StartTakeItem(1);
            cofre.PayItem(insectsideBoxes[boxIndex].GetComponent<InsecticideBox>().itemValue);
        }
    }
}