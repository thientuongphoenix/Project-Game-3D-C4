using UnityEngine;

public abstract class AttackAbstract : SaiMonoBehaviour
{
    void Update()
    {
        Attacking();
    }
    protected abstract void Attacking();
}
