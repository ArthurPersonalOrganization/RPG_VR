using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.UI
{
    public class UIDebug : MonoBehaviour
    {
        public void Messagetest(string name)
        {
            Debug.Log("clicking the UI " + name);
        }
    }
}

