using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    [SerializeField] private Item[] _dropItems;
    private float _dropChance = 0.6f;

    public void DropItem()
    {
        var rnd = Random.Range(0, 1);

        if (rnd > _dropChance) return;

        for (int i = 0; i < _dropItems.Length; i++)
        {
            Instantiate(_dropItems[i].Prefab, transform.position, Quaternion.identity);
        }
    }
}
