using UnityEngine;

public class TowerShooting : TowerAbstract
{
    [SerializeField] protected float rotationSpeed = 2f;
    [SerializeField] protected EnemyCtrl target;

    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.TargetLoading), 1f);
    }

    protected void FixedUpdate()
    {
        this.LookingAtTarget();
        //this.ShootAtTarget();
    }

    protected virtual void LookingAtTarget()
    {
        if (this.target == null) return;

        Vector3 directionToTarget = this.target.TowerTargetable.transform.position - this.towerCtrl.Rotator.position;
        Vector3 newDirection = Vector3.RotateTowards(this.towerCtrl.Rotator.forward, directionToTarget, this.rotationSpeed * Time.fixedDeltaTime, 0f);

        this.towerCtrl.Rotator.rotation = Quaternion.LookRotation(newDirection);
        //this.towerCtrl.Rotator.LookAt(this.target.TowerTargetable.transform.position);
    }

    protected virtual void TargetLoading()
    {
        Invoke(nameof(this.TargetLoading), 1f); // Đệ quy

        this.target = this.towerCtrl.TowerTargeting.Nearest;
    }
}
