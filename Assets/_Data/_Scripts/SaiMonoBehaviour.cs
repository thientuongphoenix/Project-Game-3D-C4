using UnityEngine;

public class SaiMonoBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        //this.LoadComponent();
    }

    protected virtual void Start()
    {
        this.LoadComponent();
    }

    protected virtual void Reset()
    {
        this.LoadComponent();
        this.ResetValue();
    }

    protected virtual void LoadComponent()
    {
        //For override
    }

    protected virtual void ResetValue()
    {
        //For override
    }
}
