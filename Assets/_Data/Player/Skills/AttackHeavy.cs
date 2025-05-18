using UnityEngine;

public class AttackHeavy : AttackAbstract
{
    protected override void Attacking()
    {
        if(!InputManager.Instance.IsAttackHeavy()) return;
        
        Debug.Log("Attack Heavy");
    }
}
