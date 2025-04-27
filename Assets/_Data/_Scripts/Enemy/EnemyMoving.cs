using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : SaiMonoBehaviour
{
    public GameObject target;
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected int pathIndex = 0;
    [SerializeField] protected Path enemyPath;

    protected override void Start()
    {
        this.LoadEnemyPath();
    }

    private void FixedUpdate()
    {
        this.Moving();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyCtrl();
        this.TargetMoving();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadNavMeshAgent", gameObject);
    }

    protected virtual void TargetMoving()
    {
        if (this.target != null) return;
        this.target = GameObject.Find("TargetMoving");
        Debug.Log(transform.name + ": TargetMoving", gameObject);
    }

    protected virtual void Moving()
    {
        this.enemyCtrl.Agent.SetDestination(target.transform.position);
    }

    protected virtual void LoadEnemyPath()
    {
        if(this.enemyPath != null) return;
        this.enemyPath = PathsManager.Instance.GetPath(this.pathIndex);
        Debug.Log(transform.name + ": LoadEnemyPath", gameObject);
    }
}
