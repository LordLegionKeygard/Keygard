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
        MainThread.Post(_ => _shopCanvas.Purchase(), null);                  
    }

    public void PurchaseFailure(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("Failed");
    }
}
