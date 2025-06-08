using System.Collections.Generic;
using UnityEngine;

public class EnemyBTree : BTAgent
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    public EnemyCtrl EnemyCtrl => enemyCtrl;

    public override void Start()
    {
        base.Start();

        this.BuildBehaviorTree();
    }

    public virtual void BuildBehaviorTree()
    {
        if (tree == null)
        {
            tree = new BehaviorTree();
        }
        
        // Xóa các node con cũ nếu có
        if(tree != null)
        {
            tree.children.Clear();
            tree.currentChild = 0;
        }
        

        // Lấy danh sách các Point từ EnemyMoving
        var path = enemyCtrl.EnemyMoving.EnemyPath;
        List<Point> points = new List<Point>();
        Point p = path.GetPoint(0);
        while (p != null)
        {
            points.Add(p);
            p = p.NextPoint;
        }

        // Tạo Sequence đi qua từng Point
        Sequence patrolSequence = new Sequence("Patrol Path");
        for (int i = 0; i < points.Count; i++)
        {
            int idx = i; // tránh closure bug
            Leaf goToPoint = new Leaf("Go to Point " + idx, () => GoToPoint(points[idx]));
            patrolSequence.AddChild(goToPoint);
        }

        tree.AddChild(patrolSequence);
        tree.PrintTree();
    }

    protected virtual void Reset()
    {
        this.LoadComponents();
        //this.ResetValue();
    }

    protected virtual void LoadComponents()
    {
        this.LoadEnemyCtrl();
        this.LoadAgent();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }

    protected virtual void LoadAgent()
    {
        if (this.agent != null) return;
        this.agent = this.enemyCtrl.Agent;
        Debug.Log(transform.name + ": LoadAgent", gameObject);
    }

    // Hàm di chuyển tới một Point, dùng lại logic của EnemyMoving
    public Node.Status GoToPoint(Point point)
    {
        // Kiểm tra có được phép di chuyển không
        if (!enemyCtrl.EnemyMoving.CanMove)
        {
            enemyCtrl.Agent.isStopped = true;
            return Node.Status.FAILURE;
        }

        // Kiểm tra đã chết chưa
        if (enemyCtrl.EnemyDamageReceiver.IsDead())
        {
            enemyCtrl.Agent.isStopped = true;
            return Node.Status.FAILURE;
        }

        // Kiểm tra đã đi hết path chưa
        if (point == null || enemyCtrl.EnemyMoving.IsFinish)
        {
            enemyCtrl.Agent.isStopped = true;
            return Node.Status.SUCCESS;
        }

        enemyCtrl.Agent.isStopped = false;
        enemyCtrl.Agent.SetDestination(point.transform.position);

        float distance = Vector3.Distance(enemyCtrl.transform.position, point.transform.position);
        if (distance < enemyCtrl.EnemyMoving.StopDistance)
        {
            // Cập nhật currentPoint và isFinish như logic FindNextPoint
            enemyCtrl.EnemyMoving.CurrentPoint = point.NextPoint;
            if (enemyCtrl.EnemyMoving.CurrentPoint == null)
            {
                enemyCtrl.EnemyMoving.IsFinish = true;
            }
            return Node.Status.SUCCESS;
        }
        return Node.Status.RUNNING;
    }
}
