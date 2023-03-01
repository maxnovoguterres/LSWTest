using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Enums;
using Assets.Scripts.ScriptableObjects;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class EquipmentController : Shared.Controller<EquipmentController>
    {
        private ItemSO[] currentEquipment;

        public GameObject[] currentMeshes;
        public Action<ItemSO, ItemSO> OnEquipmentChanged;

        private void Start ()
        {
            int numSlots = Enum.GetNames(typeof(EquipmentType)).Length;
            currentEquipment = new ItemSO[numSlots];
        }

        public void Equip (ItemSO newItem)
        {
            int slotIndex = (int)newItem.equipmentType;
            ItemSO oldItem = Unequip(slotIndex);
            
            OnEquipmentChanged?.Invoke(newItem, oldItem);

            currentEquipment[slotIndex] = newItem;
            foreach (GameObject mesh in currentMeshes)
            {
                if (mesh.name == newItem.name)
                {
                    mesh.SetActive(true);
                    break;
                }
            }
        }

        public ItemSO Unequip (int slotIndex)
        {
            if (currentEquipment[slotIndex] != null)
            {
                if (currentMeshes[slotIndex] != null)
                {
                    currentMeshes[slotIndex].SetActive(false);
                }

                ItemSO oldItem = currentEquipment[slotIndex];

                currentEquipment[slotIndex] = null;

                OnEquipmentChanged?.Invoke(null, oldItem);
                return oldItem;
            }
            return null;
        }
    }
}