using Script.Statistics;
using Scripts.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Statistics
{
    public class StatsUI : BaseUI
    {
        [SerializeField]
        private Stats statsObj;

        [SerializeField]
        private Transform statParent;

        [SerializeField]
        private Transform primaryStatParent;

        [SerializeField]
        private Transform dynamicStatParent;

        [SerializeField]
        private Button buttonClose;

        private List<BaseStatUI> statsUIs;
        private List<PrimaryStatUI> primaryStatUIs;
        private List<DynamicStatUI> dynamicUis;

        private void Awake()
        {
            base.Awake();
            statsUIs = statParent.GetComponentsInChildren<BaseStatUI>(true).ToList();
            primaryStatUIs = primaryStatParent.GetComponentsInChildren<PrimaryStatUI>(true).ToList();
            dynamicUis = dynamicStatParent.GetComponentsInChildren<DynamicStatUI>(true).ToList();
            Debug.Log("calling refres 1h");
            statsObj.OnInitialized += Refresh;
            buttonClose.onClick.AddListener(delegate { Hide(); });
        }

        private void Refresh()
        {
            Debug.Log("calling refre 2sh");
            foreach (var statUi in statsUIs)
            {
                Debug.Log(statUi.name);
                Stat stat = statsObj[statUi.statName];
                statUi.Refresh(stat);
                stat.OnChangedValue += statUi.Refresh;
            }
            /*
            foreach (var dynamicStatUI in dynamicUis)
            {
                DynamicStat dynamicStat = statsObj[dynamicStatUI.statName] as DynamicStat;
                dynamicStatUI.Refresh(dynamicStat);
                dynamicStat.OnChangedCurrentValue += dynamicStatUI.Refresh;
            }
            */
            foreach (var primarStatUI in primaryStatUIs)
            {
                Debug.Log(primarStatUI.name);
                Stat stat = statsObj[primarStatUI.statName];
                primarStatUI.Refresh(stat);
                stat.OnChangedValue += primarStatUI.Refresh;
            }
        }
    }
}