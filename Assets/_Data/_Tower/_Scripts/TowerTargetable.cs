using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class TowerTargetable : SaiMonoBehaviour
{
    [SerializeField] protected SphereCollider sphereCollider;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSphereCollider();
    }

    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.radius = 0.5f;
        this.sphereCollider.isTrigger = true;
        Debug.Log(transform.name + ": LoadSphereCollider", gameObject);
    }
}
