using UnityEngine;
using Scripts.UI;
using Scripts.Statistics;
using Scripts.helper;

namespace Scripts.Managers
{
    internal class UIManager : Singleton<UIManager>
    {
        public InventoryUI InventoryUI;
        public EquipmentUI EquipmentUI;
        public StatsUI StatsUI;
    }
}
