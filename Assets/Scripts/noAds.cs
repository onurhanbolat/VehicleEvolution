using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;

public class noAds : MonoBehaviour, IStoreListener
{
    private static IStoreController m_StoreController;
    private static IExtensionProvider m_ExtensionProvider;

    private static string adfree = "";

    void Start()
    {
        if (m_StoreController == null)
        {
            InitializePurchasing();
        }
        
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        throw new System.NotImplementedException();
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        throw new System.NotImplementedException();
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        throw new System.NotImplementedException();
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        if (System.String.Equals(purchaseEvent.purchasedProduct.definition.id, adfree, System.StringComparison.Ordinal))
        {
            PlayerPrefs.SetInt("reklamkodu", 1);
            GameObject.FindWithTag("AddControl").GetComponent<ADController>().noAdButton.interactable = false;
        }

        return PurchaseProcessingResult.Complete;
    }


    public void InitializePurchasing()
    {
        if (IsInitalized())
        {
            return;
        }
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct(adfree, ProductType.NonConsumable);
        UnityPurchasing.Initialize(this, builder);
    }

    public void ReklamiKaldir()
    {
        BuyProductID(adfree);
    }

    void BuyProductID(string productId)
    {
        if (IsInitalized())
        {
            Product product = m_StoreController.products.WithID(productId);
            if (product != null && product.availableToPurchase)
            {
                m_StoreController.InitiatePurchase(product);
            }
            else
            {
                Debug.Log("Satýn Alýrken Hata Oluþtu!");
            }
        }
        else
        {
            Debug.Log("Ürün Çaðrýlamýyor!");
            }
    }

    private bool IsInitalized()
    {
        return m_StoreController != null && m_ExtensionProvider != null;
    }

    
}
