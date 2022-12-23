using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Enemies
{
    public class FollowingSMB : SceneLinkedSMB<Enemy>
    {
        public override void OnSLStateNoTransitionUpdate(Animator animator,
                                                     AnimatorStateInfo stateInfo,
                                                     int layerIndex)
        {
            base.OnSLStateNoTransitionUpdate(animator, stateInfo, layerIndex);

            //check distance to destination
            Vector3 distanceTo = m_MonoBehaviour.transform.position - m_MonoBehaviour.Agent.destination;
            m_MonoBehaviour.Agent.SetDestination(m_MonoBehaviour.Target.position);
        }
        
    }

}
