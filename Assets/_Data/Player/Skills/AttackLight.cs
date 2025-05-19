using UnityEngine;

public class AttackLight : AttackAbstract
{
    protected string effectName = "Fire1";

    protected override void Attacking()
    {
        if(!InputManager.Instance.IsAttackLight()) return;

        AttackPoint attackPoint = this.GetAttackPoint();

        EffectCtrl effectCtrl = this.spawner.Spawn(this.GetEffect(), attackPoint.transform.position);
        effectCtrl.gameObject.SetActive(true);
        Debug.Log("Attack Light");
    }

    protected virtual EffectCtrl GetEffect()
    {
        return this.prefabs.GetByName(this.effectName);
    }
}
