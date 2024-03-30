using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishLayout : MonoBehaviour
{
    public GameObject fish;
    public GameObject fishSauce;
    public GameObject lemon;
    public GameObject asparagus;

    public GameObject steak;
    public GameObject steakSauce;
    public GameObject mash;
    public void Awake()
    {
        ResetAllIngredients();
    }

    public void SetNewIngredientActive(IngrediantType type)
    {
        switch (type)
        {
            case IngrediantType.Fish:
                fish.SetActive(true);
                break;
            case IngrediantType.FishSauce:
                fishSauce.SetActive(true);
                break;
            case IngrediantType.Asparagus:
                asparagus.SetActive(true);
                break;
            case IngrediantType.Lemon:
                lemon.SetActive(true);
                break;
            case IngrediantType.SteakSauce:
                steakSauce.SetActive(true);
                break;
            case IngrediantType.Steak:
                steak.SetActive(true);
                break;
            case IngrediantType.Mash:
                mash.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void ResetAllIngredients()
    {
        fish.SetActive(false);
        fishSauce.SetActive(false);
        asparagus.SetActive(false);
        lemon.SetActive(false);
        steak.SetActive(false);
        steakSauce.SetActive(false);
        mash.SetActive(false);
    }
}
