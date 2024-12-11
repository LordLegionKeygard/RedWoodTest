using System.Collections;
using UnityEngine;
using Zenject;

public class EnemiesSpawnerSystem : MonoBehaviour
{
    [Inject] EnemyFactory _enemyFactory;
    [SerializeField] private GameObject[] _enemiesPrefab;
    [SerializeField] private Transform _enemiesParent;

    private void Start()
    {
        StartCoroutine(nameof(SpawnCoroutine));
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            float time = 0;
            var rnd = Random.Range(WorldGameInfo.MinSpawnTime, WorldGameInfo.MaxSpawnTime);

            while (time <= rnd)
            {
                time += Time.deltaTime;
                yield return null;
            }

            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        var enemiesCount = Random.Range(1, WorldGameInfo.MaxEnemiesSpawnCount);

        for (int i = 0; i < enemiesCount; i++)
        {
            var rndEnemy = Random.Range(0, _enemiesPrefab.Length);

            var enemy = _enemyFactory.SpawnEnemy(_enemiesPrefab[rndEnemy], GetRandomPosition(), _enemiesParent);
            enemy.transform.SetParent(_enemiesParent);

            enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y, -3.1f);
        }
    }

    private Vector2 GetRandomPosition()
    {
        var rndX = Random.Range(0, 2) == 0 ? Random.Range(-30, -80) : Random.Range(30, 80);
        return new Vector2(rndX, -12.62f);
    }
}
