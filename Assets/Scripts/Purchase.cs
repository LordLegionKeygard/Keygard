using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Purchasing;

public class Purchase : MonoBehaviour
{
    public ShopCanvas _shopCanvas; 

    public static SynchronizationContext MainThread;

    private void Start() 
    {
        MainThread = SynchronizationContext.Current;        
    }

    public void OnPurchaseComplete(Product product) 
    {
        if (product.definition.id == "coins_200") MainThread.Post(_ => _shopCanvas.Purchase200(), null);
        else if (product.definition.id == "coins_400") MainThread.Post(_ => _shopCanvas.Purchase400(), null);
        else if (product.definition.id == "coins_1000") MainThread.Post(_ => _shopCanvas.Purchase1000(), null);                    
    }

    public void PurchaseFailure(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("Failed");
    }
}
