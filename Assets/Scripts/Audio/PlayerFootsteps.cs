using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    public void Footstep()
    {
        AudioManager.Instance.PlayerOneShot(FMODEvents.Instance.Footstep, transform.position);
    }
}
