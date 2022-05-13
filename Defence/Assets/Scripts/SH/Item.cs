using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "New Item/item")]
public class Item : ScriptableObject
{
    public enum ItemType
    {
        Battery,
        Clip,
        Gun,
        Bullet
    }
    public string itemName;
    public ItemType itemType;
    public Sprite itemImage;
    public GameObject itemPrefab;
}