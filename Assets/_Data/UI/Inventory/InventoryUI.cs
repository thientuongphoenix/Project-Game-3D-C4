using UnityEngine;

public class InventoryUI : SaiMonoBehaviour
{
    protected bool isShow = true;
    public bool IsShow => isShow;

    protected override void Start()
    {
        base.Start();
        this.Hide();
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
        this.isShow = true;
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
        this.isShow = false;
    }
}
