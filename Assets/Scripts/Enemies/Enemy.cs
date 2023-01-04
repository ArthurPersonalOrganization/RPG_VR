using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.Enemies
{
    public class Enemy : MonoBehaviour
    {
        private Animator animator;
        private NavMeshAgent agent;
        public NavMeshAgent Agent => agent;
        private Transform target;
        public Transform Target => target;

        //use this instead of everything
        public LayerMask playerLayer;
        public Collider[] hitColliders = new Collider[1];
        public float fieldOfViewAngle = 135f;
        public float fieldOfVisionRadius = 3f;
        public float patrolDistance = 2f;
        public float attackRange = 1f;
        public float timeUntilNextAttack;
        public float attackSpeed = 1f;
        public float patrollingSpeed = 2f;
        private static readonly int Attacking = Animator.StringToHash("attacking");
        private static readonly int Following = Animator.StringToHash("following");
        private static readonly int MovementSpeed = Animator.StringToHash("movement");

        private void OnEnable()
        {
            SceneLinkedSMB<Enemy>.Initialise(animator, this);
        }
        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();  
            animator = GetComponent<Animator>();

        }

        private void Update()
        {
            animator.SetFloat(MovementSpeed, agent.velocity.magnitude / agent.speed);
        }

        private void FixedUpdate()
        {
            if (target)
            {
                animator.SetBool(Attacking, Physics.CheckSphere(transform.position, attackRange, playerLayer));
                animator.SetBool(Following, Physics.CheckSphere(transform.position, fieldOfVisionRadius, playerLayer));

            }
            else
            {
                int numColliders = Physics.OverlapSphereNonAlloc(transform.position, fieldOfVisionRadius, hitColliders, playerLayer);
                for (int i = 0; i<numColliders; i++)
                {
                    //get direction of the player
                    Vector3 direction = hitColliders[i].transform.position - transform.position ;
                    Debug.Log("playes is " + direction);
                    //get the angle where the player is 
                    float angle = Vector3.Angle(direction, transform.forward); 
                   // float angle = Vector3.Angle(transform.position, direction);
                    Debug.Log("looking to " + angle);

                    if (angle < fieldOfViewAngle)
                    {
                        if(Physics.Raycast(transform.position + transform.up, direction.normalized, out RaycastHit hit, fieldOfVisionRadius))
                        {
                            target = hit.collider.transform;
                            animator.SetBool(Following, true);
                            break;
                        }
                    }
                }
            }
        }

        public void OnDrawGizmos()
        {
            Gizmos.color= Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
            Gizmos.color= Color.yellow;
            Gizmos.DrawWireSphere(transform.position, patrolDistance);
            Gizmos.color= Color.blue;
            Gizmos.DrawWireSphere(transform.position, fieldOfVisionRadius);
        }

    }

}

