using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    [SerializeField] private Item[] _dropItems;

    public void DropItem()
    {
        for (int i = 0; i < _dropItems.Length; i++)
        {
            Instantiate(_dropItems[i].Prefab, transform.position, Quaternion.identity);
        }
    }
}
