using UnityEngine;

public class TowerCtrl : SaiMonoBehaviour
{
    [SerializeField] protected Transform model;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
    }

    protected virtual void LoadModel()
    {
        if (model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }
}
