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

    protected virtual void Spawning()
    {
      Invoke(nameof(this.Spawning), this.spawnSpeed);
      EnemyCtrl prefab = this.GetEnemyPrefab();

      EnemyCtrl newEnemy = this.enemyManagerCtrl.EnemySpawner.Spawn(prefab, transform.position);
      newEnemy.gameObject.SetActive(true);

      Debug.Log("Spawning");
    }

    protected virtual EnemyCtrl GetEnemyPrefab()
    {
      return this.enemyManagerCtrl.EnemyPrefabs.GetRandom();
    }
}
