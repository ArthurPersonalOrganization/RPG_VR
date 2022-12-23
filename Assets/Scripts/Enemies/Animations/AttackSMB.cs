using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Enemies
{
    public class AttackSMB : SceneLinkedSMB<Enemy>
    {
        public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnSLStateExit(animator, stateInfo, layerIndex);
            m_MonoBehaviour.timeUntilNextAttack = Time.time + 1f / m_MonoBehaviour.attackSpeed;
        }

    }

}

