using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SaiSingleton<InventoryManager>
{
    [SerializeField] protected List<InventoryCtrl> inventories;
    [SerializeField] protected List<ItemProfileSO> itemProfiles;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventories();
    }

    protected override void Start()
    {
        base.Start();
        this.AddTestGold(100);
        this.AddTestItems(20);
        Invoke(nameof(this.AddTestItemDelay), 7f);
    }

    protected virtual void AddTestItemDelay()
    {
        this.AddTestItems(10);
    }

    protected virtual void AddTestGold(int count)
    {
        InventoryCtrl inventoryCtrl = this.GetByName(InvCodeName.Monies);

        ItemInventory gold = new ItemInventory();
        gold.itemProfile = this.GetProfileByCode(ItemCode.Gold);
        gold.itemName = "Gold";
        gold.itemCount = count;
        inventoryCtrl.AddItem(gold);
    }

    protected virtual void AddTestItems(int count)
    {
        InventoryCtrl inventoryCtrl2 = this.GetByName(InvCodeName.Items);

        for (int i = 0; i < count; i++)
        {
            ItemInventory wand = new ItemInventory();
            wand.itemProfile = this.GetProfileByCode(ItemCode.Wand);
            wand.itemName = "Wand";
            wand.itemCount = 1;

            inventoryCtrl2.AddItem(wand);
        }
    }

    protected virtual void LoadInventories()
    {
        if (this.inventories.Count > 0) return;
        foreach (Transform child in transform)
        {
            InventoryCtrl inventoryCtrl = child.GetComponent<InventoryCtrl>();
            if (inventoryCtrl == null) continue;
            this.inventories.Add(inventoryCtrl);
        }
        Debug.Log(transform.name + ": LoadInventories", gameObject);
    }

    public virtual InventoryCtrl GetByName(InvCodeName inventoryName)
    {
        foreach (InventoryCtrl inventory in this.inventories)
        {
            if(inventory.GetName() == inventoryName) return inventory;
        }
        return null;
    }

    public virtual ItemProfileSO GetProfileByCode(ItemCode itemCode)
    {
        foreach (ItemProfileSO itemProfile in this.itemProfiles)
        {
            if(itemProfile.itemCode == itemCode) return itemProfile;
        }
        return null;
    }

    public virtual InventoryCtrl Monies()
    {
        return this.GetByName(InvCodeName.Monies);
    }

    public virtual InventoryCtrl Items()
    {
        return this.GetByName(InvCodeName.Items);
    }
}
