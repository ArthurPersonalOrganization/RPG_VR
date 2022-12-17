using Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GameFoundation;

namespace Scripts.UI
{
    public class EquipmentUI : BaseUI
    {
        [SerializeField]
        private Transform slotParent;
        [SerializeField]
        private Equipment equipment;
        private Dictionary<string, EquipmentSlot> slots = new Dictionary<string, EquipmentSlot>();

        private void Awake()
        {
            base.Awake();
            foreach (var child in slotParent.GetComponentsInChildren<EquipmentSlot>(true))
            {
                slots[child.equipmentType] = child;
            }
        }

        public void SubscribeToGameFoundationEvents()
        {
            GameFoundationSdk.inventory.itemAddedToCollection += OnitemAddedToEquipment;
            GameFoundationSdk.inventory.itemRemovedFromCollection += OnItemRemovedFromEquipment;
        }

        public void UnsubscribeToGameFoundationEvents()
        {
            GameFoundationSdk.inventory.itemAddedToCollection -= OnitemAddedToEquipment;
            GameFoundationSdk.inventory.itemRemovedFromCollection -= OnItemRemovedFromEquipment;
        }

        public void OnitemAddedToEquipment(IItemCollection ItemCollection, InventoryItem inventoryItem)
        {
            if (equipment.items.id == ItemCollection.id)
            {
                slots[inventoryItem.definition.GetStaticProperty("EquipmentType").AsString()].Set(inventoryItem);
            }
        }

        public void OnItemRemovedFromEquipment(IItemCollection ItemCollection, InventoryItem inventoryItem)
        {
            if (equipment.items.id == ItemCollection.id)
            {
                slots[inventoryItem.definition.GetStaticProperty("EquipmentType").AsString()].UnSet();
            }
        }
    }

}
