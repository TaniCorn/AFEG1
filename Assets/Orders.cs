using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Orders : MonoBehaviour
{
    enum Order
    {
        Fish,
        Steak
    }
    public Plate plate;
    private List<IngrediantType> ingrediantTypes = new List<IngrediantType>();
    public Image ticketImage;

    public Sprite fishTicket;
    public Sprite steakTicket;
    private void Awake()
    {
        plate = FindObjectOfType<Plate>();
    }
    // Start is called before the first frame update
    void Start()
    {
        GetNewOrder();
    }
    public void GetNewOrder()
    {
        //Randomise order
        int rand = Random.Range(0, 2);
        Order od = Order.Fish;
        if (rand == 0)
        {
            od = Order.Steak;
        }
        else
        {
            od = Order.Fish;
        }

        ingrediantTypes = GetIngredients(od);
        plate.SetOrder(ingrediantTypes);
        if(od == Order.Fish)
        {
            ticketImage.sprite = fishTicket;
        }
        else
        {
            ticketImage.sprite = steakTicket;
        }
    }
    private List<IngrediantType> GetIngredients(Order order)
    {
        List<IngrediantType> ingredients = new List<IngrediantType>();
        switch (order)
        {
            case Order.Fish:
                ingredients.Add(IngrediantType.Fish);
                ingredients.Add(IngrediantType.Asparagus);
                ingredients.Add(IngrediantType.FishSauce);
                ingredients.Add(IngrediantType.Lemon);
                return ingredients;
            case Order.Steak:
                ingredients.Add(IngrediantType.Steak);
                ingredients.Add(IngrediantType.SteakSauce);
                ingredients.Add(IngrediantType.Mash);
                ingredients.Add(IngrediantType.Asparagus);
                return ingredients;
        }
        return ingredients;
    }
}
