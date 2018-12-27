using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPSC : MonoBehaviour, IStoreListener
{
    private static IStoreController m_StoreController;          // The Unity Purchasing system.
    private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.

    public static string money1000 = "money_1000"; // 소비 상품
    public static string money3000 = "money_3000"; // 소비 상품
    public static string money5000 = "money_5000"; // 소비 상품
    public static string money10000 = "money_10000"; // 소비 상품
    public static string money50000 = "money_50000"; // 소비 상품

    //public static string kProductIDNonConsumable = "nonconsumable"; // 소비되지 않는 상품
    //public static string kProductIDSubscription = "subscription"; // 구독 상품

    // 애플 앱스토어 프로덕트 아이덴티파이어
    //private static string kProductNameAppleSubscription = "com.unity3d.subscription.new";

    // Google Play Store-specific product identifier subscription product.
    private static string kProductNameGooglePlaySubscription = "com.unity3d.subscription.original";

    void Start()
    {
        if (m_StoreController == null)
        {
            InitializePurchasing(); // 초기화 해줌
        }
    }

    public void InitializePurchasing()
    {
        if (IsInitialized())
        {
            return;
        }
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct(money1000, ProductType.Consumable);
        builder.AddProduct(money3000, ProductType.Consumable);
        builder.AddProduct(money5000, ProductType.Consumable);
        builder.AddProduct(money10000, ProductType.Consumable);
        builder.AddProduct(money50000, ProductType.Consumable);
        // Continue adding the non-consumable product.
        //builder.AddProduct(kProductIDNonConsumable, ProductType.NonConsumable);
        //builder.AddProduct(kProductIDSubscription, ProductType.Subscription, new IDs(){
        //        //{ kProductNameAppleSubscription, AppleAppStore.Name },
        //        { kProductNameGooglePlaySubscription, GooglePlay.Name }
        //    });
        UnityPurchasing.Initialize(this, builder);
    }

    private bool IsInitialized()
    {
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }

    public void BuyProductID(string productId)
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();

        if (IsInitialized())
        {
            Product product = m_StoreController.products.WithID(productId);

            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                m_StoreController.InitiatePurchase(product);
            }
            else
            {
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        else
        {
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }

    //// Restore purchases previously made by this customer. Some platforms automatically restore purchases, like Google. 
    //// Apple currently requires explicit purchase restoration for IAP, conditionally displaying a password prompt.
    //public void RestorePurchases()
    //{
    //    if (!IsInitialized())
    //    {
    //        Debug.Log("RestorePurchases FAIL. Not initialized.");
    //        return;
    //    }

    //    if (Application.platform == RuntimePlatform.IPhonePlayer ||
    //        Application.platform == RuntimePlatform.OSXPlayer)
    //    {
    //        Debug.Log("RestorePurchases started ...");

    //        // Fetch the Apple store-specific subsystem.
    //        var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
    //        apple.RestoreTransactions((result) => {
    //            Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
    //        });
    //    }
    //    else
    //    {
    //        Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
    //    }
    //}

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("OnInitialized: PASS");
        m_StoreController = controller;
        m_StoreExtensionProvider = extensions;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {

        string pid = args.purchasedProduct.definition.id;
        switch (pid)
        {
            case "money_1000":
                PlayerState.Instance().money += 1000;
                PlayerPrefs.SetInt("money", PlayerState.Instance().money);
                break;
            case "money_3000":
                PlayerState.Instance().money += 3000;
                PlayerPrefs.SetInt("money", PlayerState.Instance().money);
                break;
            case "money_5000":
                PlayerState.Instance().money += 5000;
                PlayerPrefs.SetInt("money", PlayerState.Instance().money);
                break;
            case "money_10000":
                PlayerState.Instance().money += 10000;
                PlayerPrefs.SetInt("money", PlayerState.Instance().money);
                break;
            case "money_50000":
                PlayerState.Instance().money += 50000;
                PlayerPrefs.SetInt("money", PlayerState.Instance().money);
                break;
        }

        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }
}