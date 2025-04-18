using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrl : SaiMonoBehaviour
{
    [SerializeField] protected NavMeshAgent agent;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadNavMeshAgent();
    }

    protected virtual void LoadNavMeshAgent()
    {
        if (agent != null) return;
        agent = GetComponent<NavMeshAgent>();
        Debug.Log(transform.name + ": LoadNavMeshAgent", gameObject);
    }
}
