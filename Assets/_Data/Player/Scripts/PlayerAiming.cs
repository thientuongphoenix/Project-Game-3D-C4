using UnityEngine;

public class PlayerAiming : PlayerAbstract
{
    protected float closeLookDistance = 0.6f;
    protected float farLookDistance = 1.3f;

    private void FixedUpdate()
    {
        this.Aiming();
    }

    protected virtual void Aiming()
    {
        if(InputManager.Instance.IsRightClick()) this.LookClosed();
        else this.LookFar();
    }

    protected virtual void LookClosed()
    {
        this.playerCtrl.ThirdPersonCamera.defaultDistance = this.closeLookDistance;
    }

    protected virtual void LookFar()
    {
        this.playerCtrl.ThirdPersonCamera.defaultDistance = this.farLookDistance;
    }
}
