using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out ItemPickup itemPickup))
        {
            itemPickup.PickUp();
        }
    }
}
