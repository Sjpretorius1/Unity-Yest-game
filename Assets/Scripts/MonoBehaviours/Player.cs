using UnityEngine;

public class Player : Character
{
    public HealtBar healthBarPrefab;

    HealtBar healthBar;

    public Inventory inventoryPrefab;
    Inventory inventory;

    void Start()
    {
        inventory = Instantiate(inventoryPrefab);
        hitPoints.value = startingHitPoints;
        healthBar = Instantiate(healthBarPrefab);
        healthBar.character = this;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CanBePickedUp"))
        {

        
            Item hitObject = collision.GetComponent<Consumable>().item;

            if (hitObject != null)
            {
                bool shouldDisappear = false;

                switch (hitObject.itemType)
                {

                    case Item.ItemType.COIN:
                        shouldDisappear = inventory.AddItem(hitObject);
                        shouldDisappear = true;
                        break;

                    case Item.ItemType.HEALTH:
                        shouldDisappear = AdjustHitPoints(hitObject.quantity);
                        break;
                    default:
                        break;
                }
                if (shouldDisappear)
                {
                    collision.gameObject.SetActive(false);
                }
            }  
        }  
    }

    public bool AdjustHitPoints(int amount)
    {
        
        if(hitPoints.value < maxHitPoints)
        {
            hitPoints.value = hitPoints.value + amount;
            print("Adjust HitPoint by: " + amount + ". New value: " + hitPoints);
            return true;
        }
        return false;

    }

}
