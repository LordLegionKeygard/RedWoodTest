using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    public static FMODEvents Instance;

    [Header("PlayerSFX")]
    public EventReference Shoot;
    public EventReference TakeAmmo;
    public EventReference Footstep;
    public EventReference PlayerDeath;


    [Header("CreatureSFX")]
    public EventReference ZombieGrowl;


    // [Header("UiSFX")]


    // [Header("Environment")]


    private void Awake()
    {
        if (Instance != null) Debug.LogError("Two FMODEvents");
        Instance = this;
    }
}
