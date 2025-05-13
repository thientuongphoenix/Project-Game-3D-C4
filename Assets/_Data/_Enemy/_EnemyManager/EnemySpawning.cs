using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : EnemyManagerAbstract
{
    [SerializeField] protected float spawnSpeed = 1f;
    [SerializeField] protected int maxSpawn = 10;
    protected List<EnemyCtrl> spawnedEnemies = new();

    protected override void Start()
    {
      base.Start();
      Invoke(nameof(this.Spawning), this.spawnSpeed);
    }

    protected virtual void FixedUpdate()
    {
      this.RemoveDeadOne();
    }

    protected virtual void Spawning()
    {
      Invoke(nameof(this.Spawning), this.spawnSpeed);

      if(this.spawnedEnemies.Count > this.maxSpawn) return;

      EnemyCtrl prefab = this.GetEnemyPrefab();

      EnemyCtrl newEnemy = this.enemyManagerCtrl.EnemySpawner.Spawn(prefab, transform.position);
      newEnemy.gameObject.SetActive(true);

      this.spawnedEnemies.Add(newEnemy);
      Debug.Log("Spawning");
    }

    protected virtual EnemyCtrl GetEnemyPrefab()
    {
      return this.enemyManagerCtrl.EnemyPrefabs.GetRandom();
    }

    protected virtual void RemoveDeadOne()
    {
      foreach(EnemyCtrl enemyCtrl in this.spawnedEnemies)
      {
        if(enemyCtrl.EnemyDamageReceiver.IsDead())
        {
          this.spawnedEnemies.Remove(enemyCtrl);
          return;
        }
      }
    }
}
