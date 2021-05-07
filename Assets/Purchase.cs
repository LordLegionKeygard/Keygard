using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class Purchase : MonoBehaviour
{
    public ShopCanvas _shopCanvas; 

    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == "com.legionswordgames.add_coins")  _shopCanvas.Purchase();
    }

    public void OnPurchaseFailure(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("Purchase of " + product.definition.id + "failed because" + reason);
    }
}
