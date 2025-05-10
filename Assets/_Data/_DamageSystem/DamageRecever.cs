using UnityEngine;

public abstract class DamageRecever : SaiMonoBehaviour
{
    protected int maxHP = 10;
    protected int currentHP = 10;
    protected bool isDead = false;

    public virtual int Deduct(int hp)
    {
        this.currentHP -= hp;
        this.IsDead();

        if(this.currentHP < 0) this.currentHP = 0;
        return this.currentHP;
    }

    protected virtual bool IsDead()
    {
        return this.isDead = this.currentHP <= 0;
    }
}
