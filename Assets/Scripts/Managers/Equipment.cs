using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GameFoundation;

namespace Scripts.Managers
{
    public class Equipment : MonoBehaviour
    {
        public ItemMap items { get; private set; }
        
        // Start is called before the first frame update
        void Start()
        {
            if (items == null)
            {
                items = GameFoundationSdk.inventory.CreateMap();
            }
        }

        private void OnEnable()
        {
            EventManager.Instance.OnEquip += Equip;
        }

        private void OnDisable()
        {
            EventManager.Instance.OnEquip -= Unequip;
        }

        private void Equip(InventoryItem item)
        {
            string equipmentType = item.definition.GetStaticProperty("equipmentType").AsString();
            items.Set(equipmentType, item);
        }

        private void Unequip(InventoryItem item)
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

