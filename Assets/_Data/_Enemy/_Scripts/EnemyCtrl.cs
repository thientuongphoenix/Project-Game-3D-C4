using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrl : SaiMonoBehaviour
{
    [SerializeField] protected Transform model;
    [SerializeField] protected NavMeshAgent agent;
    public NavMeshAgent Agent => agent;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadNavMeshAgent();
        this.LoadModel();
    }

    protected virtual void LoadNavMeshAgent()
    {
        if (this.agent != null) return;
        this.agent = GetComponent<NavMeshAgent>();
        this.agent.speed = 2;
        this.agent.angularSpeed = 200;
        this.agent.acceleration = 150;
        Debug.Log(transform.name + ": LoadNavMeshAgent", gameObject);
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        this.model.localPosition = new Vector3(0, 0, 0);
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }
}
