using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public Collider[] itensDetecteds;
    public GameObject itemInHand;
    public Transform handPoint;

    private void Update()
    {
        DetectItens();
    }

    private void DetectItens()
    {
        itensDetecteds = Physics.OverlapSphere(transform.position, 5, 1 << LayerMask.NameToLayer("Coletavel"));
        if (Input.GetButtonDown("Action") && itemInHand == null)
        {
            itemBox().GetComponent<InsecticideBox>().GetInsecticideItem();
            GameObject item = GetInsecticideItem();
            item.transform.parent = handPoint;
            item.transform.position = transform.position;
        }
    }

    private GameObject itemBox()
    {
        foreach (Collider itens in itensDetecteds)
        {
            if(Vector3.Distance(transform.position, itens.transform.position) < 2f)
            {
                return itens.gameObject;
            }
        }
        return null;
    }
}
