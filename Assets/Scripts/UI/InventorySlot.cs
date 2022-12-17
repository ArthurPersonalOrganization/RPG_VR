using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.GameFoundation;
using Unity.VisualScripting;
using Scripts.Managers;

namespace Scripts.UI
{
    public class InventorySlot : BaseSlot
    {
        private void Awake()
        {
            base.Awake();
            button.onClick.AddListener(delegate { EventManager.Instance.Equip(inventoryItem); });
        }
    }
}

