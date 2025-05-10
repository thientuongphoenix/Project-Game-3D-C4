using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class BulletDamageSender : DamageSender
{
    [SerializeField] protected SphereCollider sphereCollider;
    
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSphereCollider();
    }

    protected virtual void LoadSphereCollider()
    {
        if(this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.radius = 0.05f;
        this.sphereCollider.isTrigger = true;
        Debug.Log(transform.name + " LoadSphereCollider", gameObject);
    }
}
