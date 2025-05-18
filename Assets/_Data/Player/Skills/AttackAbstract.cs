using UnityEngine;

public abstract class AttackAbstract : SaiMonoBehaviour
{
    void LateUpdate()
    {
        this.Attacking();
    }
    
    protected abstract void Attacking();
}
