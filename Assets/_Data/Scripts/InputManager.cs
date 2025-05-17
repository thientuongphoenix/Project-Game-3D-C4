using UnityEngine;

public class InputManager : SaiSingleton<InputManager>
{
    protected bool isLeftClick = false;
    protected bool isRightClick = false;

    void Update()
    {
        this.CheckRightClick();
    }

    protected virtual void CheckRightClick()
    {
        this.isRightClick = Input.GetMouseButton(1);
    }

    protected virtual void CheckLeftClick()
    {
        this.isRightClick = Input.GetMouseButton(0);
    }

    public virtual bool IsRightClick()
    {
        return this.isRightClick;
    }

    public virtual bool IsLeftClick()
    {
        return this.isLeftClick;
    }
}
