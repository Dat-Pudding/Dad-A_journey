using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Inventory", order = 1)]
public class Inventory : ScriptableObject
{
    [SerializeField] bool hasFirePot; // invSlots[] index 0
    [SerializeField] bool hasAirPot; // invSlots[] index 1
    [SerializeField] bool hasWaterPot; // invSlots[] index 2
    [SerializeField] bool hasLightPot; // invSlots[] index 3
    [SerializeField] bool hasEmptyPot; // invSlots[] index 4
    [SerializeField] bool hasKey; // invSlots[] index 5
    [SerializeField] bool hasHerb;  // invSlots[] index 6
    [SerializeField] bool hasShard; // invSlots[] index 7

    [SerializeField] int currentHerbs;  // collectTracker[] index 0
    [SerializeField] int currentShards; // collectTracker[] index 2
    [SerializeField] int currentKeys; // collectTracker[] index 4

    [SerializeField] int maxHerbs; // collectTracker[] index 1
    [SerializeField] int maxShards; // collectTracker[] index 3
    [SerializeField] int maxKeys; // collectTracker[] index 5

    public int[] stacksCurrent = new int[3]; // stores stackables/consumables
    public int[] stacksMax = new int[3]; // stores maximum amounts for stackables/consumables
}