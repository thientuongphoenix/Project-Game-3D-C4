using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class EnemyDamageReceiver : DamageRecever
{
    [SerializeField] protected CapsuleCollider capsuleCollider;
    
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCapsuleCollider();
    }

    protected virtual void LoadCapsuleCollider()
    {
        if(this.capsuleCollider != null) return;
        this.capsuleCollider = GetComponent<CapsuleCollider>();
        this.capsuleCollider.center = new Vector3(0, 1, 0);
        this.capsuleCollider.radius = 0.3f;
        this.capsuleCollider.height = 1.5f;
        this.capsuleCollider.isTrigger = true;
        Debug.Log(transform.name + " LoadCapsuleCollider", gameObject);
    }
}
