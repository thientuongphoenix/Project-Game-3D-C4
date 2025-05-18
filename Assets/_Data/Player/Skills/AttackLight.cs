using UnityEngine;

public class AttackLight : AttackAbstract
{
    protected override void Attacking()
    {
        if(!InputManager.Instance.IsAttackLight()) return;

        Debug.Log("Attack Light");
    }
}
