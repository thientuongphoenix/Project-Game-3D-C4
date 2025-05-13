using System.Collections.Generic;
using UnityEngine;

public class TowerCtrl : SaiMonoBehaviour
{
    [SerializeField] protected Transform model;
    [SerializeField] protected Transform rotator;
    public Transform Rotator => rotator;

    [SerializeField] protected TowerTargeting towerTargeting;
    public TowerTargeting TowerTargeting => towerTargeting;

    [SerializeField] protected BulletSpawner bulletSpawner;
    public BulletSpawner BulletSpawner => bulletSpawner;

    protected string bulletName = "Bullet";
    [SerializeField] protected Bullet bullet;
    public Bullet Bullet => bullet;

    [SerializeField] protected BulletPrefabs bulletPrefabs;
    public BulletPrefabs BulletPrefabs => bulletPrefabs;

    [SerializeField] protected List<FirePoint> firePoints = new();
    public List<FirePoint> FirePoints => firePoints;

    protected override void Awake()
    {
        base.Awake();
        this.HidePrefabs();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
        this.LoadTowerTargeting();
        this.LoadBulletSpawner();
        
        this.LoadBulletPrefabs();
        this.LoadFirePoints();
    }

    protected virtual void LoadBulletSpawner()
    {
        if(this.bulletSpawner != null) return;
        this.bulletSpawner = FindFirstObjectByType<BulletSpawner>();
        Debug.Log(transform.name + ": LoadBulletSpawner", gameObject);
    }

    protected virtual void LoadBullet()
    {
        if(this.bullet != null) return;
        this.bullet = this.bulletPrefabs.GetByName(this.bulletName);
        Debug.Log(transform.name + ": LoadBullet", gameObject);
    }

    protected virtual void LoadBulletPrefabs()
    {
        if(this.bulletPrefabs != null) return;
        this.bulletPrefabs = GameObject.FindAnyObjectByType<BulletPrefabs>();
        Debug.Log(transform.name + ": LoadBulletPrefabs", gameObject);

        this.LoadBullet();
    }

    protected virtual void LoadModel()
    {
        if (model != null) return;
        this.model = transform.Find("Model");
        this.rotator = this.model.Find("Rotator");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void LoadTowerTargeting()
    {
        if (towerTargeting != null) return;
        this.towerTargeting = transform.GetComponentInChildren<TowerTargeting>();
        Debug.Log(transform.name + ": LoadTowerTargeting", gameObject);
    }

    protected virtual void LoadFirePoints()
    {
        if(this.firePoints.Count > 0) return;
        FirePoint[] points = transform.GetComponentsInChildren<FirePoint>();
        this.firePoints = new List<FirePoint>(points);
        Debug.Log(transform.name + ": LoadFirePoints", gameObject);
    }

    protected virtual void HidePrefabs()
    {
        this.bullet.gameObject.SetActive(false);
    }
}
