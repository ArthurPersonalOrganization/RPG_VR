using UnityEngine;
using Project.Scripts;
using Scripts.UI;
using Scripts.Statistics;

namespace Scripts.Managers
{
    internal class UIManager : Singleton<UIManager>
    {
        public InventoryUI InventoryUI;
        public EquipmentUI EquipmentUI;
        public StatsUI StatsUI;
    }
}
