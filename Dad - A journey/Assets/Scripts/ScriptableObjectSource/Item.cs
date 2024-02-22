using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]

public class Item : ScriptableObject
{
    public Sprite itemSprite;
    public string itemName;
    public string itemType;
    public string itemDescription;
    public int itemCount;
    public bool hasAcquired;

    public string[] itemNames =
{
        "Herb",
        "Key",
        "Pot Shard",
        "Fire Pot",
        "Water Pot",
        "Air Pot",
        "Light Pot",
        "Empty Pot"
    };

    public string[] itemTypes =
    {
        "Consumables",
        "Pots",
        "Misc"
    };

    public string[] itemDescriptions =
    {
        "As you learned from your father, this type of plant is the ideal emergency treatment for wounds - as long as it's not life-threatening that is.",
        "Keys unlock things. But why does everyone seemingly have the same lock everwhere?",
        "If you can get enough of them, maybe with some glue you can get an as-good-as-new pot?",
        "No one understands wherefrom this pot draws seemingly infinite energy. One guy who tried looking into the opening got immediately incinerated. Just be grateful that it doesn't burn your hands while holding it!",
        "Your pot runneth over!",
        "Don't get this near your ears, you will hear it - once",
        "Less bright than a modern flashlight. And way more clunky and cumbersome to handle. And a lot heavier as well. But hey, it works without batteries!",
        "As empty vessels make the loudest sound. ~ P"
    };
}