using UnityEngine;
//using Invector.vCharacterController;

public class PlayerAiming : PlayerAbstract
{
    [SerializeField] protected bool isAlwaysAiming = false;
    protected float closeLookDistance = 0.8f;
    protected float farLookDistance = 1.5f;

    private void Update()
    {
        this.Aiming();
    }

    protected virtual void Aiming()
    {
        if (this.isAlwaysAiming || InputManager.Instance.IsRightClick()) this.LookClose();
        else this.LookFar();
    }

    protected virtual void LookClose()
    {
        // this.playerCtrl.ThirdPersonCamera.defaultDistance = this.closeLookDistance;

        // CrosshairPointer crosshairPointer = this.playerCtrl.CrosshairPointer;
        // this.playerCtrl.ThirdPersonController.RotateToPosition(crosshairPointer.transform.position);
        // //this.playerCtrl.ThirdPersonController.locomotionType = vThirdPersonMotor.LocomotionType.OnlyStrafe;
        // this.playerCtrl.ThirdPersonController.isSprinting = false;

        //this.playerCtrl.AimingRig.weight = 1f;
    }

    protected virtual void LookFar()
    {
        //this.playerCtrl.ThirdPersonCamera.defaultDistance = this.farLookDistance;
        //this.playerCtrl.ThirdPersonController.locomotionType = vThirdPersonMotor.LocomotionType.FreeWithStrafe;
        //this.playerCtrl.AimingRig.weight = 0f;
    }
}
