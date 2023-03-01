using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.ScriptableObjects;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class InventoryController : Shared.Controller<InventoryController>
    {
        public Action<ItemSO> OnItemAdded;
        public Action<ItemSO> OnItemRemoved;

        public int space = 20;

        public List<ItemSO> items = new List<ItemSO>();

        public bool Add (ItemSO item)
        {
            if (items.Count >= space)
            {
                return false;
            }

            items.Add(item);

            OnItemAdded?.Invoke(item);
            return true;
        }

        public void Remove (ItemSO item)
        {
            items.Remove(item);

            OnItemRemoved?.Invoke(item);
        }
    }
}