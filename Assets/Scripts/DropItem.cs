using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item",menuName ="New Item/item")]
public class DropItem : ScriptableObject
{

    public string itemName;
    public ItemType itemType;
    public Sprite itemImage;
    public GameObject itemPrefab;

    public enum ItemType
    {
        EQUIPMENT,
        USED,
        INGREDIENT,
        ETC
    }


}
