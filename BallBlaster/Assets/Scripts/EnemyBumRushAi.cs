using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class EnemyBumRushAi : MonoBehaviour
{
    public StarterAssets.FirstPersonController firstPersonController; // Assign in Inspector
    private NavMeshAgent agent;
    public Transform player;
    public float sightRange = 10f; // Set the sight range

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        // player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {

        if (agent != null && agent.enabled && player != null)
        {
            Vector3 directionToPlayer = player.position - transform.position;
            float distanceToPlayer = directionToPlayer.magnitude;

            // Raycast to check if player is within sight distance and visible
            if (distanceToPlayer <= sightRange)
            {
                Ray ray = new Ray(transform.position, directionToPlayer.normalized);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, sightRange))
                {
                    if (hit.transform.CompareTag("Player"))
                    {
                        agent.SetDestination(player.position);
                    }
                }
            }
        }
    }
    private void FixedUpdate()
    {
        // Prevent NavMeshAgent and Rigidbody from fighting each other
        Rigidbody rb = GetComponent<Rigidbody>();
        if (agent != null && rb != null)
        {
            if (rb.linearVelocity.magnitude > 5f)
            {
                if (agent.enabled)
                {
                    agent.enabled = false;
                    Debug.Log("NavMeshAgent disabled, the linear velocity is " + rb.linearVelocity.magnitude);
                }
            }
            else
            {
                if (!agent.enabled)
                {
                    agent.enabled = true;
                    rb.linearVelocity = Vector3.zero;
                    Debug.Log("NavMeshAgent re-enabled, the linear velocity is " + rb.linearVelocity.magnitude);
                }
            }
        }
    }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         if (collision.gameObject.TryGetComponent<StarterAssets.FirstPersonController>(out var controller))
    //         {
    //             Vector3 forceDirection = (collision.transform.position - transform.position).normalized;
    //             controller.PushPlayer(forceDirection * 1000f); // Adjust force magnitude as needed
    //         }
    //     }
    // }
    
    private void OnDrawGizmosSelected()
    {
        // Gizmos.color = Color.red;
        // Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
    
}
