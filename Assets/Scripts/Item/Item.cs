using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "RedWoodTest/Item")]
public class Item : ScriptableObject
{
    public ItemType ItemType;
    public GameObject Prefab;

}

public enum ItemType
{
    None = 0,
    Ammo = 1,
}