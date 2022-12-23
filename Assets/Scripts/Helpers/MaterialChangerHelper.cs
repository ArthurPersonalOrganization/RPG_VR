using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static RootMotion.Demos.Turret;

namespace Scripts.Helper
{
    public class MaterialChangerHelper : MonoBehaviour
    {
        public Material newMaterial;
        public List<Transform> parents;

        public void ChangeMaterials()
        {

            for (int i = 0; i < parents.Count; i++)
            {
                foreach (Transform child in parents[i])
                {
                    if (child.GetComponent<SkinnedMeshRenderer>() != null)
                    {
                        child.GetComponent<SkinnedMeshRenderer>().material = newMaterial;
                    }

                }
            }

          
        }
    }

}
