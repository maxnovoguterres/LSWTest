using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    public Sprite defaultIcon;
    public Image icon;
    public TextMeshProUGUI nameText;

    void Start()
    {
        ClearSlot();
    }

    public void Setup(ItemSO item)
    {
        icon.sprite = item.icon;
        nameText.text = item.name;
    }

    public void ClearSlot()
    {
        icon.sprite = defaultIcon;
        nameText.text = string.Empty;
    }
}
