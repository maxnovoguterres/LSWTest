using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Controller;
using Assets.Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

public class ShopSection : Section
{
    public ShopItem shopItemPrefab;
    public GameObject buyTab;
    public GameObject sellTab;
    public Image buyTabImage;
    public Image sellTabImage;
    public Transform armorBuyItemParent;
    public Transform armorSellItemParent;
    public List<ItemSO> armorShopItemsSO;

    private ShopItem currentBuyItemSelected;
    private ShopItem currentSellItemSelected;

    void Start()
    {
        OnShowSection += Setup;

        CreateShopItems();
        HideSection();
    }

    public void OnClickCloseButton()
    {
        HideSection();
    }

    public void OnClickArmorsButton ()
    {

    }

    public void OnClickBuyTabButton ()
    {
        buyTab.SetActive(true);
        sellTab.SetActive(false);
        buyTabImage.color = new Color(0.5f, 0.5f, 0.5f, 1);
        sellTabImage.color = Color.white;
    }

    public void OnClickSellTabButton ()
    {
        buyTab.SetActive(false);
        sellTab.SetActive(true);
        buyTabImage.color = Color.white;
        sellTabImage.color = new Color(0.5f, 0.5f, 0.5f, 1);
    }

    public void OnClickBuyButton ()
    {
        if (currentBuyItemSelected != null)
        {
            bool wasBought = InventoryController.Instance.Add(currentBuyItemSelected.shopItem);
            if (wasBought)
            {
                ShopItem newShopItem = Instantiate(shopItemPrefab, Vector3.zero, Quaternion.identity, armorSellItemParent);
                newShopItem.Setup(currentBuyItemSelected.shopItem, true);
                newShopItem.GetComponent<Button>().onClick.AddListener(() => OnClickSellItemButton(newShopItem));

                CoinController.Instance.RemoveCoins(currentBuyItemSelected.shopItem.coinValue);
                Destroy(currentBuyItemSelected.gameObject);
            }
        }
    }

    public void OnClickSellButton ()
    {
        if (currentSellItemSelected != null)
        {
            InventoryController.Instance.Remove(currentSellItemSelected.shopItem);
            ShopItem newShopItem = Instantiate(shopItemPrefab, Vector3.zero, Quaternion.identity, armorBuyItemParent);
            newShopItem.Setup(currentSellItemSelected.shopItem);
            newShopItem.GetComponent<Button>().onClick.AddListener(() => OnClickBuyItemButton(newShopItem));

            CoinController.Instance.AddCoins(currentSellItemSelected.shopItem.coinValue / 2);
            Destroy(currentSellItemSelected.gameObject);
        }
    }

    private void OnClickBuyItemButton(ShopItem shopItem)
    {
        currentBuyItemSelected = shopItem;
    }

    private void OnClickSellItemButton (ShopItem shopItem)
    {
        currentSellItemSelected = shopItem;
    }

    private void Setup ()
    {
        OnClickBuyTabButton();
    }

    private void CreateShopItems()
    {
        foreach (ItemSO armorShopItemSO in armorShopItemsSO)
        {
            ShopItem newShopItem = Instantiate(shopItemPrefab, Vector3.zero, Quaternion.identity, armorBuyItemParent);
            newShopItem.Setup(armorShopItemSO);
            newShopItem.GetComponent<Button>().onClick.AddListener(() => OnClickBuyItemButton(newShopItem));
        }
    }
}
