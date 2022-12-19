using System;
using UnityEngine;

namespace Scripts.Statistics
{
    public class Stat
    {
        public string name;
        [SerializeField] private int baseValue;

        public int BaseValue
        {
            get { return baseValue; }
            set { baseValue = value; }
        }

        public int Value { get; set; }

        public event Action<Stat> OnChangedValue;

        public Stat(string name, int baseValue)
        {
            this.name = name;
            BaseValue = baseValue;
            Value = baseValue;
        }
    }
}