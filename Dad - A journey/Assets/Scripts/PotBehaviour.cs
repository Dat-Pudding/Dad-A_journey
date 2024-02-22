using UnityEngine;

public class PotBehaviour : MonoBehaviour
{
    public Pot potData;

    void Start()
    {
        potData.hasAcquired = false;
        potData.itemName = potData.itemNames[potData.nameSelect];
        potData.itemType = potData.itemTypes[potData.typeSelect];
        potData.itemDescription = potData.itemDescriptions[potData.descriptionSelect];
        potData.itemSprite = this.GetComponentInChildren<SpriteRenderer>().sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            potData.hasAcquired = true;
            Destroy(gameObject);
        }
    }
}