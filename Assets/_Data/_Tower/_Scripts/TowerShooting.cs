using UnityEngine;

public class TowerShooting : TowerAbstract
{
    [SerializeField] protected int currentFirePoint = 0;
    [SerializeField] protected float targetLoadSpeed = 1f;
    [SerializeField] protected float shootingSpeed = 1f;
    [SerializeField] protected float rotationSpeed = 2f;
    [SerializeField] protected EnemyCtrl target;
    [SerializeField] protected BulletSpawner bulletSpawner;
    [SerializeField] protected Bullet bullet;
    

    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.TargetLoading), this.targetLoadSpeed);
        Invoke(nameof(this.Shooting), this.shootingSpeed);
    }

    protected void FixedUpdate()
    {
        this.Looking();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
    }

    protected virtual void Looking()
    {
        if (this.target == null) return;

        Vector3 directionToTarget = this.target.TowerTargetable.transform.position - this.towerCtrl.Rotator.position;
        Vector3 newDirection = Vector3.RotateTowards(this.towerCtrl.Rotator.forward, directionToTarget, this.rotationSpeed * Time.fixedDeltaTime, 0f);

        this.towerCtrl.Rotator.rotation = Quaternion.LookRotation(newDirection);
        //this.towerCtrl.Rotator.LookAt(this.target.TowerTargetable.transform.position);
    }

    protected virtual void TargetLoading()
    {
        Invoke(nameof(this.TargetLoading), this.targetLoadSpeed); // Đệ quy

        this.target = this.towerCtrl.TowerTargeting.Nearest;
    }

    protected virtual void Shooting()
    {
        Invoke(nameof(this.Shooting), this.shootingSpeed);
        if (this.target == null) return;

        FirePoint firePoint = this.GetFirePoint();
        Bullet newBullet = this.towerCtrl.BulletSpawner.Spawn(this.towerCtrl.Bullet, firePoint.transform.position);
        newBullet.gameObject.SetActive(true);
    }

    protected virtual FirePoint GetFirePoint()
    {
        FirePoint firePoint = this.towerCtrl.FirePoints[this.currentFirePoint];

        this.currentFirePoint++;
        if(this.currentFirePoint == this.towerCtrl.FirePoints.Count) this.currentFirePoint = 0;
        return firePoint;
    }
}
