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

        // Code mới: RandomSelector theo tỉ lệ 50/25/25
        Leaf goToNearestTower = new Leaf("Go To Nearest Tower", GoToNearestTower);
        Leaf goToPlayer = new Leaf("Go To Player", GoToPlayer);
        Leaf goToNextPoint = new Leaf("Go To Next Point", GoToNextPoint);

        var children = new List<Node> { goToNextPoint, goToPlayer, goToNearestTower };
        var weights = new List<float> { 0.5f, 0.25f, 0.25f };
        RandomSelectorEnemy randomSelector = new RandomSelectorEnemy(children, weights);
        tree.AddChild(randomSelector);
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
        // Luôn cập nhật point mới trước khi di chuyển
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

        // Luôn cập nhật point mới nếu đã đến nơi
        enemyCtrl.EnemyMoving.FindNextPoint();
        point = enemyCtrl.EnemyMoving.CurrentPoint;

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
            // Đã đến nơi, lần tick sau sẽ FindNextPoint tiếp
            return Node.Status.SUCCESS;
        }
        return Node.Status.RUNNING;
    }

    // Hàm di chuyển tới Tower gần nhất
    public Node.Status GoToNearestTower()
    {
        if (enemyCtrl.EnemyDamageReceiver.IsDead())
        {
            enemyCtrl.Agent.isStopped = true;
            return Node.Status.FAILURE;
        }

        var targeting = enemyCtrl.EnemyTargeting;
        if (targeting == null || targeting.NearestTower == null) return Node.Status.FAILURE;
        var tower = targeting.NearestTower;
        if (tower.TowerDamageReceiver != null && tower.TowerDamageReceiver.IsDead()) return Node.Status.FAILURE;
        enemyCtrl.Agent.isStopped = false;
        enemyCtrl.Agent.SetDestination(tower.transform.position);
        float distance = Vector3.Distance(enemyCtrl.transform.position, tower.transform.position);
        if (distance < enemyCtrl.EnemyMoving.StopDistance)
        {
            // Có thể bổ sung logic tấn công tower ở đây
            Debug.Log("Enemy đã đến gần Tower: " + tower.name);
            return Node.Status.SUCCESS;
        }
        return Node.Status.RUNNING;
    }

    // Hàm di chuyển tới Player
    public Node.Status GoToPlayer()
    {
        if (enemyCtrl.EnemyDamageReceiver.IsDead())
        {
            enemyCtrl.Agent.isStopped = true;
            return Node.Status.FAILURE;
        }

        var targeting = enemyCtrl.EnemyTargeting;
        if (targeting == null || targeting.Player == null) return Node.Status.FAILURE;
        var player = targeting.Player;
        // Có thể kiểm tra player chết không nếu cần
        enemyCtrl.Agent.isStopped = false;
        enemyCtrl.Agent.SetDestination(player.transform.position);
        float distance = Vector3.Distance(enemyCtrl.transform.position, player.transform.position);
        if (distance < enemyCtrl.EnemyMoving.StopDistance)
        {
            // Có thể bổ sung logic tấn công player ở đây
            return Node.Status.SUCCESS;
        }
        return Node.Status.RUNNING;
    }

    // Hàm di chuyển tới point tiếp theo (giữ nguyên logic cũ)
    public Node.Status GoToNextPoint()
    {
        if (enemyCtrl.EnemyDamageReceiver.IsDead())
        {
            enemyCtrl.Agent.isStopped = true;
            return Node.Status.FAILURE;
        }
        
        return GoToPoint(enemyCtrl.EnemyMoving.CurrentPoint);
    }

    /*
        Root
└── Selector
    ├── Combat Selector (Nếu phát hiện Tower/Player ở gần)
    │   ├── Attack Tower Sequence (25%)
    │   │   ├── Check Nearest Tower
    │   │   ├── Go To Nearest Tower
    │   │   └── Attack Tower
    │   ├── Attack Player Sequence (25%)
    │   │   ├── Check Player
    │   │   ├── Go To Player
    │   │   └── Attack Player
    │   └── Continue Moving (50%)
    │       └── Go To Next Point
    └── Patrol Sequence (Nếu không có combat)
        └── Go To Next Point (lặp qua các point)
        */
}
