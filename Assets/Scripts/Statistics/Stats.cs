using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Statistics
{
    public class Stats : MonoBehaviour
    {
        public event Action OnInitialized;
        private List<Stat> stats;

        private void Start()
        {
            stats = new List<Stat>();

        }

    }
}
