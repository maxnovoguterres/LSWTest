using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Controller;
using Assets.Scripts.Enums;
using Assets.Scripts.ScriptableObjects;
using RotaryHeart.Lib.SerializableDictionary;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySection : Section
{
    public Item itemPrefab;
    public SerializableDictionaryBase<EquipmentType, EquipmentSlot> equipmentSlots;
    public Image armorTabImage;
    public TextMeshProUGUI coinValueText;
    public Transform itemsParent;

    private List<Item> items;
    private Item currentItemSelected;

    void Start ()
    {
        items = new List<Item>();

        InventoryController.Instance.OnItemAdded += OnItemAdded;
        InventoryController.Instance.OnItemRemoved += OnItemRemoved;
        OnShowSection += UpdateCoin;

        armorTabImage.color = new Color(0.5f, 0.5f, 0.5f, 1);
        HideSection();
    }

    public void OnClickCloseButton ()
    {
        HideSection();
    }

    public void OnClickArmorTabButton ()
    {

    }

    public void OnClickEquipButton ()
    {
        if (currentItemSelected != null)
        {
            equipmentSlots[currentItemSelected.item.equipmentType].Setup(currentItemSelected.item);
            EquipmentController.Instance.Equip(currentItemSelected.item);
        }
    }

    private void OnClickItemButton (Item item)
    {
        currentItemSelected = item;
    }

    private void UpdateCoin()
    {
        coinValueText.text = CoinController.Instance.currentCoins.ToString();
    }

    private void OnItemAdded(ItemSO itemAdded)
    {
        Item newItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity, itemsParent);
        newItem.Setup(itemAdded);
        newItem.GetComponent<Button>().onClick.AddListener(() => OnClickItemButton(newItem));
        items.Add(newItem);
    }

    private void OnItemRemoved(ItemSO itemRemoved)
    {
        foreach (Item item in items)
        {
            if (item.item == itemRemoved)
            {
                Destroy(item.gameObject);
                items.Remove(item);
                break;
            }
        }
    }
}
