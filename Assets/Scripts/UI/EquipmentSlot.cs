using Scripts.Managers;

namespace Scripts.UI
{
    public class EquipmentSlot : BaseSlot
    {
        public string equipmentType;

        private void Awake()
        {
            base.Awake();
            button.onClick.AddListener(delegate { EventManager.Instance.Unequip(inventoryItem); });
        }
    }
}