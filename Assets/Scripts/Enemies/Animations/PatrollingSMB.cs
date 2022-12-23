using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

namespace Scripts.Enemies
{
    public class PatrollingSMB : SceneLinkedSMB<Enemy>
    {
        private float agentSpeed = 1f;

        //every frame will be called
        public override void OnSLStateNoTransitionUpdate(Animator animator,
                                                        AnimatorStateInfo stateInfo,
                                                        int layerIndex)
        {
            base.OnSLStateNoTransitionUpdate(animator, stateInfo, layerIndex);

            //check distance to destination
            Vector3 distanceTo = m_MonoBehaviour.transform.position - m_MonoBehaviour.Agent.destination;

            if (distanceTo.magnitude < 0.1f)//never reach zero
            {
                SampleNavMesh();
                m_MonoBehaviour.StartCoroutine(Wait(1.5f));
            }
        }

        //change speeds depding if its patrolling or engaged in other thing
        public override void OnSLStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
        {
            base.OnSLStateEnter(animator, stateInfo, layerIndex);
            agentSpeed = m_MonoBehaviour.Agent.speed;
            m_MonoBehaviour.Agent.speed = m_MonoBehaviour.patrollingSpeed;

        }

        public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnSLStateExit(animator, stateInfo, layerIndex);
            m_MonoBehaviour.Agent.speed = agentSpeed;
        }

        private IEnumerator Wait(float duration)
        {
            m_MonoBehaviour.Agent.isStopped = true;
            yield return new WaitForSeconds(duration);
            m_MonoBehaviour.Agent.isStopped = false;
        }

        //patrol to random points
        //find a random position, check if its inside our Agent patrol distance, the assign it
        private void SampleNavMesh()
        {
            Vector3 randomPoint = m_MonoBehaviour.transform.position +
                                    UnityEngine.Random.insideUnitSphere * m_MonoBehaviour.patrolDistance;

            if (NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, 1.0f, NavMesh.AllAreas))
            {
                m_MonoBehaviour.Agent.SetDestination(hit.position);
            }
        }
    }
}