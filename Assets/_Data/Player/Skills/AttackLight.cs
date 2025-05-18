using UnityEngine;

public class AttackLight : AttackAbstract
{
    protected override void Attacking()
    {
        if(!InputManager.Instance.IsAttackLight()) return;

        AttackPoint attackPoint = this.GetAttackPoint();

        Debug.Log("Attack Light");
        Debug.Log("attackPoint: " + attackPoint.transform.position);
    }
}
