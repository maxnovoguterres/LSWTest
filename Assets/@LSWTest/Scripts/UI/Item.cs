using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Controller;
using Assets.Scripts.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [HideInInspector] public ItemSO item;

    public Image icon;
    public TextMeshProUGUI nameText;
    public GameObject equippedText;

    void Start()
    {
        EquipmentController.Instance.OnEquipmentChanged += OnEquipmentChanged;
    }

    public void Setup (ItemSO newItem)
    {
        icon.sprite = newItem.icon;
        nameText.text = newItem.name;
        item = newItem;
    }

    public void OnEquipmentChanged (ItemSO newItem, ItemSO oldItem)
    {
        if (newItem != null)
        {
            if (newItem == item)
            {
                equippedText.SetActive(newItem == item);
            }
        }
        else
        {
            equippedText.SetActive(false);
        }
    }
}
