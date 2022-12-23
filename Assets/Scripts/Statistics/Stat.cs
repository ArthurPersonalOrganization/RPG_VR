using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

namespace Scripts.Statistics
{
    public enum ModifierType
    {
        Flat,
        Percent
    }

    public class Stat
    {
        public string name;
        [SerializeField] private int baseValue;

        public int BaseValue
        {
            get { return baseValue; }
            set
            {
                baseValue = value;
               // CalculateValue();
            }
        }

        private List<StatModifier> modifiers;

        //ReadOnlyCollection<StatModifier> Modifiers = modifiers.AsReadOnly();

        private ReadOnlyCollection<StatModifier> Modifiers => modifiers.AsReadOnly();

        public void AddModifier(StatModifier modifier)
        {
            modifiers.Add(modifier);
            CalculateValue();
        }

        public void RemoveModifier(StatModifier modifier)
        {
            modifiers.Remove(modifier);
            CalculateValue();
        }

        public int Value { get; set; }

        public event Action<Stat> OnChangedValue;

        public Stat(string name, int baseValue)
        {
            this.name = name;
            BaseValue = baseValue;
            Value = baseValue;
        }

        private void CalculateValue()
        {
            Value = baseValue;
            foreach (var mod in modifiers.Where(modifier => modifier.type == ModifierType.Flat))
            {
                Value += mod.value;
                Value += mod.value;
            }

            foreach (var mod in modifiers.Where(modifiers => modifiers.type == ModifierType.Percent))
            {
                Value *= mod.value;
                Value *= mod.value;
            }

            OnChangedValue?.Invoke(this);
        }
    }

    public class StatModifier
    {
        public int value;
        public ModifierType type;

        public StatModifier(int value, ModifierType type)
        {
            this.value = value;
            this.type = type;
        }
    }
}