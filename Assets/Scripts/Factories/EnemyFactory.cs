using UnityEngine;
using Zenject;

public class EnemyFactory
{
    private DiContainer _diContainer;

    public EnemyFactory(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }

    public GameObject SpawnEnemy(GameObject prefab, Vector2 position, Transform parent)
    {
        var enemy = _diContainer.InstantiatePrefab(prefab, position, Quaternion.identity, null);
        enemy.transform.SetParent(parent);

        return enemy;
    }
}
