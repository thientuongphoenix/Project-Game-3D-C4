using UnityEngine;

public class TextPlayerExpCount : TextAbstract
{
    protected virtual void FixedUpdate()
    {
        this.LoadCount();
    }

    protected virtual void LoadCount()
    {
        ItemInventory item = InventoryManager.Instance.Currency().FindItem(ItemCode.PlayerExp);
        string count;
        if (item == null) count = "0";
        else count = item.itemCount.ToString();
        this.textPro.text = count;
    }
}
