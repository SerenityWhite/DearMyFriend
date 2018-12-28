using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

namespace CompleteProject
{
    public class Purchaser : MonoBehaviour, IStoreListener
    {
        private static IStoreController m_StoreController;
        private static IExtensionProvider m_StoreExtensionProvider;

        public static string money1000 = "money_1000"; // 소비 상품
        public static string money3000 = "money_3000"; // 소비 상품
        public static string money5000 = "money_5000"; // 소비 상품
        public static string money10000 = "money_10000"; // 소비 상품
        public static string money50000 = "money_50000"; // 소비 상품
        private static string kProductNameGooglePlaySubscription = "com.unity3d.subscription.original";

        void Start()
        {
            if (m_StoreController == null)
            {
                InitializePurchasing();
            }
        }

        public void InitializePurchasing()
        {
            if (IsInitialized())
            {
                // ... we are done here.
                return;
            }

            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

            // Add a product to sell / restore by way of its identifier, associating the general identifier
            // with its store-specific identifiers.
            builder.AddProduct(money1000, ProductType.Consumable);
            builder.AddProduct(money3000, ProductType.Consumable);
            builder.AddProduct(money5000, ProductType.Consumable);
            builder.AddProduct(money10000, ProductType.Consumable);
            builder.AddProduct(money50000, ProductType.Consumable);
            UnityPurchasing.Initialize(this, builder);
        }

        private bool IsInitialized()
        {
            return m_StoreController != null && m_StoreExtensionProvider != null;
        }

        public void BuyConsumable01()
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
            SoundSC.Instance().Sound.Play();
            Debug.Log("BuyConsumalbe01!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            BuyProductID(money1000);
        }
        public void BuyConsumable02()
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
            SoundSC.Instance().Sound.Play();

            BuyProductID(money3000);
        }
        public void BuyConsumable03()
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
            SoundSC.Instance().Sound.Play();

            BuyProductID(money5000);
        }
        public void BuyConsumable04()
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
            SoundSC.Instance().Sound.Play();

            BuyProductID(money10000);
        }
        public void BuyConsumable05()
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
            SoundSC.Instance().Sound.Play();

            BuyProductID(money50000);
        }

        void BuyProductID(string productId)
        {
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
            if (String.Equals(args.purchasedProduct.definition.id, money1000, StringComparison.Ordinal))
            {
                Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
                PlayerState.Instance().money += 1000;
                PlayerPrefs.SetInt("money", PlayerState.Instance().money);
            }
            //else if (String.Equals(args.purchasedProduct.definition.id, money3000, StringComparison.Ordinal))
            //{
            //    Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            //    PlayerState.Instance().money += 3000;
            //    PlayerPrefs.SetInt("money", PlayerState.Instance().money);
            //}
            //else if (String.Equals(args.purchasedProduct.definition.id, money5000, StringComparison.Ordinal))
            //{
            //    Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            //    PlayerState.Instance().money += 5000;
            //    PlayerPrefs.SetInt("money", PlayerState.Instance().money);
            //}
            //else if (String.Equals(args.purchasedProduct.definition.id, money10000, StringComparison.Ordinal))
            //{
            //    Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            //    PlayerState.Instance().money += 10000;
            //    PlayerPrefs.SetInt("money", PlayerState.Instance().money);
            //}
            //else if (String.Equals(args.purchasedProduct.definition.id, money50000, StringComparison.Ordinal))
            //{
            //    Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            //    PlayerState.Instance().money += 50000;
            //    PlayerPrefs.SetInt("money", PlayerState.Instance().money);
            //}
            else
            {
                Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
            }
            return PurchaseProcessingResult.Complete;
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
            Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
        }
    }
}