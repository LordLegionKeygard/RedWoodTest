using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private Item _item;

    public void PickUp()
    {
        switch (_item.ItemType)
        {
            case ItemType.Ammo:
                AddRandomAmmo();
                break;
        }
        
        Destroy(transform.parent.gameObject);
    }

    private void AddRandomAmmo()
    {
        var rnd = Random.Range(1, 10);
        CustomEvents.FireChangeBullets(rnd);
    }
}
