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
            if(itemBox() == null)
            {
                return;
            }
            GameObject item = itemBox().GetComponent<InsecticideBox>().GetInsecticideItem();
            item.transform.parent = handPoint;
            item.transform.position = handPoint.transform.position;
            itemInHand = item;
        }
    }

    private GameObject itemBox()
    {
        Collider closestItem = null;
        float closestDistance = float.MaxValue;
        foreach (Collider itens in itensDetecteds)
        {
            float distance = Vector3.Distance(transform.position, itens.transform.position);
            if(distance < closestDistance && distance < 2f)
            {
                closestDistance = distance;
                closestItem = itens;
                return closestItem.gameObject;
            }
        }
        return null;
    }
}
