using UnityEngine;

public class WandCtrl : SaiMonoBehaviour
{
    protected override void ResetValue()
    {
        base.ResetValue();
        transform.localPosition = new Vector3(0.004f, 0.059f, 0.017f);
        transform.localRotation = Quaternion.Euler(-35.652f, 18.413f, 62.431f);
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
}
