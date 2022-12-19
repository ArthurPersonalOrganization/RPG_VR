using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GameFoundation;

namespace Scripts.Managers
{
    public class Equipment : MonoBehaviour
    {
        public ItemMap items { get; private set; }
        [SerializeField] private Transform primaryWeaponParent;
        private List<GameObject> primaryWeapons = new List<GameObject>();
        private int currentPrimaryWeaponId = -1;

        private void Awake()
        {
            foreach (Transform child in primaryWeaponParent)
            {
                primaryWeapons.Add(child.gameObject);
            }
        }

        // Start is called before the first frame update
        private void Start()
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
            EnablePrimaryWeapon(item);
        }

        private void Unequip(InventoryItem item)
        {
            DisablePrimaryWeapon();
        }

        private void EnablePrimaryWeapon(InventoryItem inventoryItem)
        {
            int id = primaryWeapons.FindIndex(go => go.name == inventoryItem.definition.displayName);
            primaryWeapons[id].SetActive(true);
            Debug.Log("current primary weapon id "+ id);

            currentPrimaryWeaponId = id;
        }

        private void DisablePrimaryWeapon()
        {
            primaryWeapons[currentPrimaryWeaponId].SetActive(true);
            currentPrimaryWeaponId = -1;
        }

        public GameObject GetCurrentPrimaryWeapon()
        {
            return currentPrimaryWeaponId != -1 ? primaryWeapons[currentPrimaryWeaponId] : null;
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}