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
        this.AddTestItems();
    }

    protected virtual void AddTestItems()
    {
        InventoryCtrl inventoryCtrl = this.GetByName(InvCodeName.Monies);

        ItemInventory gold = new ItemInventory();
        gold.itemProfile = this.GetProfileByCode(ItemCode.Gold);
        gold.itemName = "Gold";
        gold.itemCount = 1000;
        inventoryCtrl.AddItem(gold);

        // ItemInventory gold2 = new ItemInventory();
        // gold2.itemProfile = this.GetProfileByCode(ItemCode.Gold);
        // gold2.itemCount = 2;
        // inventoryCtrl.AddItem(gold2);

        InventoryCtrl inventoryCtrl2 = this.GetByName(InvCodeName.Items);

        for (int i = 0; i < 20; i++)
        {
            ItemInventory wand = new ItemInventory();
            wand.itemProfile = this.GetProfileByCode(ItemCode.Wand);
            wand.itemName = "Wand";
            wand.itemCount = 1;

            inventoryCtrl2.AddItem(wand);
        }

        // ItemInventory wand2 = new ItemInventory();
        // wand2.itemProfile = this.GetProfileByCode(ItemCode.Wand);
        // wand2.itemCount = 1;
        // inventoryCtrl2.AddItem(wand2);
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
