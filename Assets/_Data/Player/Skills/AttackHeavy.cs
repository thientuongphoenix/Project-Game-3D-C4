using UnityEngine;

public class AttackHeavy : AttackAbstract
{
    protected void Update()
    {
        this.Attacking();
    }

    protected override void Attacking()
    {
        if(InputManager.Instance.IsAttackHeavy()) Debug.Log("Attack Heavy");
    }
}
