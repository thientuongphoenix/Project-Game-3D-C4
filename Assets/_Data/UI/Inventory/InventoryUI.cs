using UnityEngine;

public class InventoryUI : SaiSingleton<InventoryUI>
{
    protected bool isShow = true;
    public bool IsShow => isShow;

    protected override void Start()
    {
        base.Start();
        this.Show();
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

    public virtual void Toggle()
    {
        if(this.isShow) this.Hide();
        else this.Show();
    }
}
