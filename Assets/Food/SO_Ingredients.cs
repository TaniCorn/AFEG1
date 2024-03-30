using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "FoodScriptable", menuName = "ScriptableObjects/Food")]
public class SO_Ingredients : ScriptableObject
{

    public Sprite image;
    public IngrediantType type;

}
public enum IngrediantType
{
    Fish,
    FishSauce,
    Asparagus,
    Lemon,
    Steak,
    SteakSauce,
    Mash
}