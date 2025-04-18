using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : MonoBehaviour
{
    public GameObject target;
    public NavMeshAgent agent;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        agent.SetDestination(target.transform.position);
    }
}
