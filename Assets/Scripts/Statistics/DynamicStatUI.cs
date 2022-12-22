using TMPro;
using UnityEngine;

namespace Scripts.Statistics
{
    public class DynamicStatUI : BaseStatUI
    {
        [SerializeField] private TMP_Text currentValue;
        public override void Refresh(Stat stat)
        {
            base.Refresh(stat);
            currentValue.text = (stat as DynamicStat).CurrentValue.ToString();
        }
    }
}