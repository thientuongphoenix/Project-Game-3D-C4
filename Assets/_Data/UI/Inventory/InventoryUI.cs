using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : SaiSingleton<InventoryUI>
{
    protected bool isShow = true;
    public bool IsShow => isShow;

    [SerializeField] protected BtnItemInventory defaultItemInventoryUI;
    protected List<BtnItemInventory> btnItems = new();

    protected override void Start()
    {
        base.Start();
        this.Show();
        this.HideDefaultItemInventory();
    }

    protected virtual void FixedUpdate()
    {
        this.ItemUpdating();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBtnItemInventory();
    }

    protected virtual void LoadBtnItemInventory()
    {
        if (this.defaultItemInventoryUI != null) return;
        this.defaultItemInventoryUI = GetComponentInChildren<BtnItemInventory>();
        Debug.Log(transform.name + ": LoadBtnItemInventory", gameObject);
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

    protected virtual void HideDefaultItemInventory()
    {
        this.defaultItemInventoryUI.gameObject.SetActive(false);
    }

    protected virtual void ItemUpdating()
    {
        InventoryCtrl itemInvCtrl = InventoryManager.Instance.Items();
        foreach(ItemInventory itemInventory in itemInvCtrl.Items)
        {
            BtnItemInventory newItemUI = this.GetExistItem(itemInventory);
            if(newItemUI == null)
            {
                // newItemUI = Instantiate(this.defaultItemInventoryUI);
                // newItemUI.transform.parent = this.defaultItemInventoryUI.transform.parent;
                // newItemUI.gameObject.SetActive(true);
            }
        }
    }

    protected virtual BtnItemInventory GetExistItem(ItemInventory itemInventory)
    {
        foreach(BtnItemInventory itemInvUI in this.btnItems)
        {

        }
        return null;
    }
}
