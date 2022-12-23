using Scripts.Managers;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GameFoundation;

namespace Scripts.Statistics
{
    public class Stats : MonoBehaviour
    {
        public event Action OnInitialized;

        public List<Stat> stats;

        private void OnEnable()
        {
            EventManager.Instance.OnEquip += AddEquipmentModifiers;
            EventManager.Instance.OnUnequip += RemoveEquipmentModifiers;
        }

        private void OnDisable()
        {
            EventManager.Instance.OnEquip -= AddEquipmentModifiers;
            EventManager.Instance.OnUnequip -= RemoveEquipmentModifiers;
        }

        private void Awake()
        {
            if (stats == null)
            {
                Debug.Log("Init the stat List");

                stats = new List<Stat>()
                {
                    new Stat(StatType.STRENGTH, 5),
                    new Stat(StatType.PERCEPTION, 5),
                    new Stat(StatType.ENDURANCE, 5),
                    new Stat(StatType.CHARISMA, 5),
                    new Stat(StatType.INTELLIGENCE, 5),
                    new Stat(StatType.AGILITY, 5),
                    new Stat(StatType.LUCK, 5),
                    new Stat(StatType.PHYSICAL_ATTACK, 5),
                    new Stat(StatType.PHYSICAL_DEFENSE, 5),
                    new Stat(StatType.MAGIC_ATTACK, 5),
                    new Stat(StatType.MAGIC_DEFENSE, 5),
                    new Stat(StatType.HEALTH, 100),
                    new Stat(StatType.STAMINA, 100),
                    new Stat(StatType.MANA, 100)
                };
            }
            Debug.Log("stats list " + stats.Count);
            OnInitialized?.Invoke();
        }

        public Stat this[string name]
        {
            get => stats.Find(stat => stat.name == name);
            set
            {
                int index = stats.FindIndex(stat => stat.name == name);
                if (index == -1)
                {
                    stats[index] = value;
                }
                else
                {
                    stats.Add(value);
                }
            }
        }

        private void AddEquipmentModifiers(InventoryItem item)
        {
            foreach (var mutable in item.GetMutableProperties())
            {
                Stat stat = stats.Find(st => st.name == mutable.Key);
                stat.AddModifier(new StatModifier(mutable.Value.AsInt(), ModifierType.Flat));
            }
        }

        private void RemoveEquipmentModifiers(InventoryItem item)
        {
            foreach (var mutable in item.GetMutableProperties())
            {
                Stat stat = stats.Find(st => st.name == mutable.Key);
                stat.RemoveModifier(new StatModifier(mutable.Value.AsInt(), ModifierType.Flat));
            }
        }
    }
}