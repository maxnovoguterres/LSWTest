using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Controller;
using Assets.Scripts.Enums;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
	[CreateAssetMenu(fileName = "New Item", menuName = "Scriptable Objects/Item")]
    public class ItemSO : ScriptableObject
    {
        public Sprite icon;
        public new string name;
        public int coinValue;
        public EquipmentType equipmentType;
        public SkinnedMeshRenderer mesh;
    }
}