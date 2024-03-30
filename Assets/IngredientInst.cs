using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientInst : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sprite;
    public IngrediantType ingrediantType;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    public void SetIngredient(SO_Ingredients ingredients)
    {
        sprite.sprite = ingredients.image;
        ingrediantType = ingredients.type;
    }
}
