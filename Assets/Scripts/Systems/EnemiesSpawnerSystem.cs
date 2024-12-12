using System.Collections;
using UnityEngine;
using Zenject;

public class EnemiesSpawnerSystem : MonoBehaviour
{
    [Inject] EnemyFactory _enemyFactory;
    [SerializeField] private GameObject[] _enemiesPrefab;
    [SerializeField] private Transform _enemiesParent;
    [SerializeField] private int _enemiesSpawnCount;
    private Coroutine _coroutine;
    private Transform _cameraTransform;

    private void Start()
    {
        _cameraTransform = Camera.main.transform;
        _coroutine = StartCoroutine(nameof(SpawnCoroutine));

        CustomEvents.OnGameEnd += GameEndStopCoroutine;
    }

    private IEnumerator SpawnCoroutine()
    {
        while (_enemiesSpawnCount <= WorldGameInfo.MaxGameEnemiesCount)
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
        var enemiesCount = Random.Range(WorldGameInfo.MinEnemiesSpawnCount, WorldGameInfo.MaxEnemiesSpawnCount);

        for (int i = 0; i < enemiesCount; i++)
        {
            if (_enemiesSpawnCount >= WorldGameInfo.MaxGameEnemiesCount) return;

            var rndEnemy = Random.Range(0, _enemiesPrefab.Length);

            var enemy = _enemyFactory.SpawnEnemy(_enemiesPrefab[rndEnemy], GetRandomPosition(), _enemiesParent);
            enemy.transform.SetParent(_enemiesParent);

            var rndPosZ = Random.Range(-3.1f, -3.9f);

            enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y, rndPosZ);

            _enemiesSpawnCount++;
        }
    }

    private Vector2 GetRandomPosition()
    {
        var posX = _cameraTransform.position.x;
        var rndPosX = Random.Range(0, 2) == 0 ? Random.Range(posX - 30, posX - 50) : Random.Range(posX + 30, posX + 50);
        return new Vector2(rndPosX, -12.62f);
    }

    private void GameEndStopCoroutine(GameEndEnum _)
    {
        StopCoroutine(_coroutine);
    }

    private void OnDestroy()
    {
        CustomEvents.OnGameEnd -= GameEndStopCoroutine;
    }
}
