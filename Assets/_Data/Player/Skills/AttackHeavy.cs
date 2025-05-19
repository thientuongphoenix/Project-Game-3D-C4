using UnityEngine;

public class AttackHeavy : AttackAbstract
{
    protected string effectName = "Fire2";

    protected override void Attacking()
    {
        if(!InputManager.Instance.IsAttackHeavy()) return;

        AttackPoint attackPoint = this.GetAttackPoint();

        EffectCtrl effect = this.spawner.Spawn(this.GetEffect(), attackPoint.transform.position);

        EffectFlyAbstract effectFly = (EffectFlyAbstract)effect;
        effectFly.FlyToTarget.SetTarget(this.playerCtrl.CrosshairPointer.transform);

        effect.gameObject.SetActive(true);
        //Debug.Log("Attack Light");
    }

    protected virtual EffectCtrl GetEffect()
    {
        return this.prefabs.GetByName(this.effectName);
    }
}
