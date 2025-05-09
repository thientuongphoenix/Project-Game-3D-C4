using UnityEngine;

public class BulletSpawner : Spawner
{
    //Method Overloading
    public virtual Bullet Spawn(Bullet bulletPrefab)
    {
        Bullet newObject = Instantiate(bulletPrefab);
        newObject.Despawn.SetSpawner(this);
        return newObject;
    }

    public virtual Bullet Spawn(Bullet bulletPrefab, Vector3 position)
    {
        Bullet newBullet = this.Spawn(bulletPrefab);
        newBullet.transform.position = position;

        return newBullet;
    }
}
