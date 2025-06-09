using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class EnemyTargeting : SaiMonoBehaviour
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody rigid;

    [SerializeField] protected List<TowerCtrl> towers = new();
    public List<TowerCtrl> Towers => towers;

    [SerializeField] protected PlayerCtrl player;
    public PlayerCtrl Player => player;

    [SerializeField] protected LayerMask obstacleLayerMask;

    [SerializeField] protected TowerCtrl nearestTower;
    public TowerCtrl NearestTower => nearestTower;

    protected virtual void FixedUpdate()
    {
        this.FindNearestTower();
        //this.FindPlayer();
        //this.RemoveDeadTower();
    }

    protected virtual void OnTriggerEnter(Collider collider)
    {
        this.AddTower(collider);
        this.AddPlayer(collider);
    }

    protected virtual void OnTriggerExit(Collider collider)
    {
        this.RemoveTower(collider);
        this.RemovePlayer(collider);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadRigidbody();
    }

    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.radius = 5f;
        this.sphereCollider.isTrigger = true;
        Debug.Log(transform.name + ": LoadSphereCollider", gameObject);
    }

    protected virtual void LoadRigidbody()
    {
        if(this.rigid != null) return;
        this.rigid = GetComponent<Rigidbody>();
        this.rigid.useGravity = false;
        Debug.Log(transform.name + ": LoadRigidbody", gameObject);
    }

    protected virtual void AddTower(Collider collider)
    {
        if (collider.name != Const.ENEMY_TARGETABLE) return;
        TowerCtrl towerCtrl = collider.transform.parent.GetComponent<TowerCtrl>();
        if(towerCtrl == null) return;
        if(towerCtrl.TowerDamageReceiver != null && towerCtrl.TowerDamageReceiver.IsDead()) return;
        if(this.towers.Contains(towerCtrl)) return;
        this.towers.Add(towerCtrl);
    }

    protected virtual void RemoveTower(Collider collider)
    {
        foreach(TowerCtrl towerCtrl in this.towers)
        {
            if(collider.transform.parent == towerCtrl.transform)
            {
                this.towers.Remove(towerCtrl);
                return;
            }
        }
    }

    protected virtual void AddPlayer(Collider collider)
    {
        if (collider.name != Const.ENEMY_TARGETABLE) return;
        PlayerCtrl playerCtrl = collider.transform.parent.GetComponent<PlayerCtrl>();
        if(playerCtrl == null) return;
        //if(playerCtrl.PlayerDamageReceiver != null && playerCtrl.PlayerDamageReceiver.IsDead()) return;
        this.player = playerCtrl;
    }

    protected virtual void RemovePlayer(Collider collider)
    {
        if (this.player == null) return;
        if (collider.transform.parent == this.player.transform)
        {
            this.player = null;
        }
    }

    protected virtual void FindPlayer()
    {
        // Có thể mở rộng logic tìm player gần nhất nếu có nhiều player
        // Hiện tại chỉ lấy player đầu tiên trong vùng
    }

    protected virtual void RemoveDeadTower()
    {
        foreach (TowerCtrl towerCtrl in this.towers)
        {
            //if(towerCtrl.TowerDamageReceiver != null && towerCtrl.TowerDamageReceiver.IsDead()) 
            {
                this.towers.Remove(towerCtrl);
                return;
            }
        }
    }

    protected virtual void FindNearestTower()
    {
        float nearestDistance = Mathf.Infinity;
        float towerDistance;
        foreach(TowerCtrl towerCtrl in this.towers)
        {
            // Nếu muốn kiểm tra tầm nhìn, có thể bổ sung hàm CanSeeTarget tương tự TowerTargeting
            towerDistance = Vector3.Distance(transform.position, towerCtrl.transform.position);
            if(towerDistance < nearestDistance)
            {
                nearestDistance = towerDistance;
                this.nearestTower = towerCtrl;
            }
        }
    }
}
