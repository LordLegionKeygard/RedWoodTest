using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private Item _item;

    public void PickUp()
    {
        switch (_item.ItemType)
        {
            case ItemType.Ammo:
                AudioManager.Instance.PlayerOneShot(FMODEvents.Instance.TakeAmmo, transform.position);
                AddRandomAmmo();
                break;
        }

        Destroy(transform.parent.gameObject);
    }

    private void AddRandomAmmo()
    {
        var rnd = Random.Range(10, 25);
        CustomEvents.FireChangeBullets(rnd);
    }
}
