using UnityEngine;

public class InputHotkeys : SaiSingleton<InputHotkeys>
{
    [SerializeField] protected bool isToggleInventoryUI = false;
    public bool IsToggleInventoryUI => isToggleInventoryUI;

    protected virtual void Update()
    {
        this.OpenInventory();
    }

    protected virtual void OpenInventory()
    {
        this.isToggleInventoryUI = Input.GetKeyUp(KeyCode.I);
    }
}
