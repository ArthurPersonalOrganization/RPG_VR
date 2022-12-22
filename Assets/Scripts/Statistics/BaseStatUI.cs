using Newtonsoft.Json.Schema;
using TMPro;
using UnityEngine;

namespace Scripts.Statistics
{
    public class BaseStatUI : MonoBehaviour
    {
        [SerializeField] protected TMP_Text value;
        public string statName;
        public StatsUI container;
        public virtual void Refresh(Stat stat)
        {
            value.text = stat.Value.ToString();
        }
    }
}