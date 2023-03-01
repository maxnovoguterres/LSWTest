using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [HideInInspector] public ItemSO shopItem;

    public Image itemIcon;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI coinValueText;

    public void Setup(ItemSO newShopItem, bool isSelling = false)
    {
        itemIcon.sprite = newShopItem.icon;
        nameText.text = newShopItem.name;
        coinValueText.text = isSelling ? (newShopItem.coinValue / 2).ToString() : newShopItem.coinValue.ToString();
        shopItem = newShopItem;
    }
}
