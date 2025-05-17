using UnityEngine;

public class AimingRightHand_hint : SaiMonoBehaviour
{
    protected override void ResetValue()
    {
        base.ResetValue();
        transform.localPosition = new Vector3(20.10173f, 1.227f, -14.07131f);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}
