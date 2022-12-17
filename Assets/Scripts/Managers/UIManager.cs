using UnityEngine;
using Project.Scripts;
using Scripts.UI;

namespace Scripts.Managers
{
    internal class UIManager : Singleton<UIManager>
    {
        public InventoryUI InventoryUI;
        public EquipmentUI EquipmentUI;
    }
}
