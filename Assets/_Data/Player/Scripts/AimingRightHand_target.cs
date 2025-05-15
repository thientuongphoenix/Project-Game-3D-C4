using UnityEngine;

public class AimingRightHand_target : SaiMonoBehaviour
{
    protected override void ResetValue()
    {
        base.ResetValue();
        transform.localPosition = new Vector3(20.044f, 1.379263f, -13.787f);
        transform.localRotation = Quaternion.Euler(149.502f, 90.341f, 90.974f);
    }
}
