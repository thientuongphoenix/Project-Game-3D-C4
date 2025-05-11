using UnityEngine;

public abstract class DamageRecever : SaiMonoBehaviour
{
    protected int maxHP = 10;
    protected int currentHP = 10;
    protected bool isDead = false;
    [SerializeField] protected bool isImmotal = false;

    public virtual int Deduct(int hp)
    {
        if(!isImmotal) this.currentHP -= hp;
        if(this.IsDead())
        {
            this.OnDead();
        }
        else
        {
            this.OnHurt();
        }

        if(this.currentHP < 0) this.currentHP = 0;
        return this.currentHP;
    }

    public virtual bool IsDead()
    {
        return this.isDead = this.currentHP <= 0;
    }

    protected virtual void OnDead()
    {
        // For Override
    }

    protected virtual void OnHurt()
    {
        // For Override
    }
}
