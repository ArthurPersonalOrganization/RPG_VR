
using Scripts.helper;
using System;
using UnityEngine;
using UnityEngine.GameFoundation;

namespace Scripts.Managers
{
    public class EventManager : Singleton<EventManager>
    {
        public event Action OnShowUI;
        public event Action OnHideUI;
        public void ShowUI() => OnShowUI?.Invoke();
        public void HideUI() => OnHideUI?.Invoke();

        public event Action<InventoryItem> OnEquip;

        public event Action<InventoryItem> OnUnequip;

        public void Equip(InventoryItem item) => OnEquip?.Invoke(item);

        public void Unequip(InventoryItem item) => OnUnequip?.Invoke(item);

    }

}

