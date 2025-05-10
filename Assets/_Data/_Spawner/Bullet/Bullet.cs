using UnityEngine;

public class Bullet : PoolObj
{
    [SerializeField] protected float speed = 10f;

    public override string GetName()
    {
        return "Bullet";
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }

    // protected override void LoadComponent()
    // {
    //     base.LoadComponent();
    //     this.LoadDespawn();
    // }

    // protected virtual void LoadDespawn()
    // {
    //     if (this.despawn != null) return;
    //     this.despawn = transform.GetComponentInChildren<BulletDespawn>();
    //     Debug.Log(transform.name + ": LoadDespawn", gameObject);
    // }
}
