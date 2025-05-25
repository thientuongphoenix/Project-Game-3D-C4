using UnityEngine;

public class InputHotkeys : SaiSingleton<InputHotkeys>
{
    [SerializeField] protected bool isToggleInventoryUI = false;
    public bool IsToggleInventoryUI => isToggleInventoryUI;

    public bool isToogleMusic = false;

    protected virtual void Update()
    {
        this.OpenInventory();
        this.ToogleMusic();
    }

    protected virtual void OpenInventory()
    {
        this.isToggleInventoryUI = Input.GetKeyUp(KeyCode.I);
    }

    protected virtual void ToogleMusic()
    {
        this.isToogleMusic = Input.GetKeyUp(KeyCode.M);
    }
}
