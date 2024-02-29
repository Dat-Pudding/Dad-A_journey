using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Inventory", order = 1)]
public class Inventory : ScriptableObject
{
    public bool hasFirePot;
    public bool hasAirPot;
    public bool hasWaterPot;
    public bool hasLightPot;
    public bool hasEmptyPot;
    public bool hasKey;
    public bool hasHerb;
    public bool hasShard;

    public int currentHerbs;
    public int currentShards;
    public int currentKeys;

    public int maxHerbs;
    public int maxShards;
    public int maxKeys;
}