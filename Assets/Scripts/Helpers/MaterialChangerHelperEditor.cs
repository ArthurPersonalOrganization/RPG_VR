using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Scripts.Helper
{

    [CustomEditor(typeof(MaterialChangerHelper))]
    public class MaterialChangerHelperEditor : Editor
    {
        public MaterialChangerHelper helper;

        public override void OnInspectorGUI()
        {
           DrawDefaultInspector();
            MaterialChangerHelper helper = (MaterialChangerHelper)target;
            if (GUILayout.Button("Change materials"))
            {
                helper.ChangeMaterials();
            }
        }

    }

}
