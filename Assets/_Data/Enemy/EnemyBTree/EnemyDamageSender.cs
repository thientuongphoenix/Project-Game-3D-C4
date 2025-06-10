using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public abstract class EnemyDamageSender : DamageSender
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected SphereCollider sphereCollider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.GetComponentInParent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }

    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.radius = 0.15f;
        this.sphereCollider.isTrigger = true;
        Debug.Log(transform.name + ": LoadSphereCollider", gameObject);
    }

    protected override void Send(DamageReceiver damageReceiver, Collider collider)
    {
        base.Send(damageReceiver, collider);
        //this.ShowHitEffect(collider);

        //this.enemyCtrl.Despawn.DoDespawn();
    }

    // protected virtual void ShowHitEffect(Collider collider)
    // {
    //     //Lấy điểm va chạm giữa 2 collider bằng ClosestPoint
    //     Vector3 hitPoint = collider.ClosestPoint(transform.position);
    //     EffectCtrl prefab = EffectSpawnerCtrl.Instance.Spawner.PoolPrefabs.GetByName(this.GetHitName());
    //     EffectCtrl newEffect = EffectSpawnerCtrl.Instance.Spawner.Spawn(prefab, hitPoint);
    //     newEffect.gameObject.SetActive(true);
    // }

    protected abstract string GetHitName();
}
