using System;
using UnityEngine;
namespace Scripts.Statistics
{
    public class DynamicStat : Stat
    {
        public int CurrentValue
        {
            get { return CurrentValue; }
            set { currentValue = Mathf.Clamp(value, 0, Value); }
        }

        private int currentValue;

        public event Action<DynamicStat> OnChangedCurrentValue;

        public DynamicStat(string name, int baseValue) : base(name,baseValue)
        {
            currentValue = baseValue;
        }
    }
}