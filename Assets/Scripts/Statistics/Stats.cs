using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Scripts.Statistics
{
    public class Stats : MonoBehaviour
    {
        public event Action OnInitialized;
        public List<Stat> stats;

        private void Start()
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
            Debug.Log("stats list "+stats.Count);
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
    }
}
