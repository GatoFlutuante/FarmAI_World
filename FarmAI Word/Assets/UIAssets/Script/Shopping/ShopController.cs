using UnityEngine;

public class ShopController : MonoBehaviour
{
    public GameObject shopping;
    public bool inShop;

    private void Update()
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
}
