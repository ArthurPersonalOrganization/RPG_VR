using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.GameFoundation;
using UnityEngine.UI;

namespace Scripts.UI
{
    public class InventoryUI : BaseUI
    {
        [SerializeField]
        private Inventory inventory;

        [SerializeField]
        private Transform slotParent;

        [SerializeField]
        private Button closeButton;

        public List<InventorySlot> slots;

        private void Awake()
        {
            base.Awake();
            slots = slotParent.GetComponentsInChildren<InventorySlot>(includeInactive: true).ToList();
            closeButton.onClick.AddListener(call: delegate { Hide(); });
        }

        public void SubscribeToGameFoundationEvents()
        {
            GameFoundationSdk.inventory.itemAddedToCollection += OnItemAddedToInventory;
            GameFoundationSdk.inventory.itemRemovedFromCollection += OnItemRemovedFromInventory;
        }

        public void UnsubscribeToGameFoundationEvents()
        {
            GameFoundationSdk.inventory.itemAddedToCollection -= OnItemAddedToInventory;
            GameFoundationSdk.inventory.itemRemovedFromCollection -= OnItemRemovedFromInventory;
        }

        private void OnItemAddedToInventory(IItemCollection itemCollection, InventoryItem inventoryItem)
        {
            if (inventory.Items.id == itemCollection.id)
            {
                foreach (var slot in slots)
                {
                    if (slot.inventoryItem == null)
                    {
                        slot.Set(inventoryItem);
                        break;
                    }
                }
            }
        }

        private void OnItemRemovedFromInventory(IItemCollection itemCollection, InventoryItem inventoryItem)
        {
            if (inventory.Items.id == itemCollection.id)
            {
                ItemList inventory = itemCollection as ItemList;
                int index = inventory.IndexOf(inventoryItem);
                slots[index].UnSet();
            }
        }
    }
}