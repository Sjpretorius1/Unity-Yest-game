using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    public string objectname;

    public Sprite sprite;

    public int quantity;

    public bool stackable;

    public enum ItemType
    {
        COIN,
        HEALTH
    }
    
    public ItemType itemType;
}
