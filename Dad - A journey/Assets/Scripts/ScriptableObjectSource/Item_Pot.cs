using UnityEngine;

[CreateAssetMenu(fileName = "Pot", menuName = "Items/Pots", order = 1)]
public class Pot : Item
{
    [Header("Pot Composer")]
    public int nameSelect;
    public int typeSelect;
    public int descriptionSelect;
}