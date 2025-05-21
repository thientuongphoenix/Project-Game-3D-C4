using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;

public class InventoryTester : SaiMonoBehaviour
{
    [ProButton]
    public virtual void AddTestGold(int count)
    {
        InventoryCtrl inventoryCtrl = InventoryManager.Instance.GetByName(InvCodeName.Monies);

        ItemInventory gold = new ItemInventory();
        gold.itemProfile = InventoryManager.Instance.GetProfileByCode(ItemCode.Gold);
        gold.itemName = "Gold";
        gold.itemCount = count;
        inventoryCtrl.AddItem(gold);
    }
    
    [ProButton]
    public virtual void AddTestItems(int count)
    {
        InventoryCtrl inventoryCtrl2 = InventoryManager.Instance.GetByName(InvCodeName.Items);

        for (int i = 0; i < count; i++)
        {
            ItemInventory wand = new ItemInventory();
            wand.itemProfile = InventoryManager.Instance.GetProfileByCode(ItemCode.Wand);
            wand.itemName = "Wand";
            wand.itemCount = 1;

            inventoryCtrl2.AddItem(wand);
        }
    }
}
