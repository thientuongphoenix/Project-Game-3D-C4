using System.Security.Cryptography;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class DamageSender : SaiMonoBehaviour
{
    [SerializeField] protected Rigidbody rigid;
    [SerializeField] protected int damage = 1;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadRigidbody();
    }

    protected virtual void LoadRigidbody()
    {
        if(this.rigid != null) return;
        this.rigid = GetComponent<Rigidbody>();
        this.rigid.useGravity = false;
        Debug.Log(transform.name + " LoadRigidbody", gameObject);
    }

    public virtual void OnTriggerEnter(Collider collider)
    {
        DamageRecever damageRecever = collider.GetComponent<DamageRecever>();
        if (damageRecever == null) return;
        this.Send(damageRecever);
        Debug.Log("OnTriggerEnter: " + collider.name);
    }

    protected virtual void Send(DamageRecever damageRecever)
    {
        damageRecever.Deduct(this.damage);
    }    
}
