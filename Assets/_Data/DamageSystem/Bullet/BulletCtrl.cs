using UnityEngine;

public class BulletCtrl : SaiMonoBehaviour
{
    [SerializeField] protected Bullet bullet;
    public Bullet Bullet => bullet;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBullet();
    }

    protected virtual void LoadBullet()
    {
        if(this.bullet != null) return;
        this.bullet = GetComponent<Bullet>();
        Debug.Log(transform.name + " LoadBullet", gameObject);
    }
}
