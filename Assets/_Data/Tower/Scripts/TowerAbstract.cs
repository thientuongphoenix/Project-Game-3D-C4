using UnityEngine;

public abstract class TowerAbstract : SaiMonoBehaviour
{
    [SerializeField] protected TowerCtrl towerCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTowerCtrl();
    }

    protected virtual void LoadTowerCtrl()
    {
        if (this.towerCtrl != null) return;
        this.towerCtrl = transform.parent.GetComponent<TowerCtrl>();
        Debug.Log(transform.name + ": LoadTowerCtrl", gameObject);
    }
}
