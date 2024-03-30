using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TODO: 
public class Plate : MonoBehaviour
{
    public float radius = 2.0f;
    public List<IngrediantType> ingredientsRequired = new List<IngrediantType>();
    public Sprite failedPlate;
    public Sprite plate;
    public DishLayout dishLayout;

    public AudioSource audioSource;
    public AudioClip successClip;
    public AudioClip addClip;
    public AudioClip dingClip;
    public AudioClip failedClip;
    public AudioClip angryClip;

    float fadetime = 1.0f;
    bool fade = false;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void UseIngredient(IngrediantType type)
    {
        if (ingredientsRequired.Contains(type))
        {
            //Dish Succeeded
            ingredientsRequired.Remove(type);
            dishLayout.SetNewIngredientActive(type);
            audioSource.PlayOneShot(addClip);
        }
        else
        {
            //Dish Failed
            FailedPlate();
        }
    }
    public void SetOrder(List<IngrediantType> ingredients)
    {
        ingredientsRequired = ingredients;
    }
    public void Ding()
    {
        audioSource.PlayOneShot(dingClip);
        if (ingredientsRequired.Count == 0)
        {
            FinishedPlate();
        }
    }
    private void FinishedPlate()
    {
        audioSource.PlayOneShot(successClip);
        FindObjectOfType<Fail>().DishSucceded();
        fade = true;
    }
    private void FailedPlate()
    {
        if (FindObjectOfType<Chef>().inKitchen)
        {
            audioSource.PlayOneShot(angryClip);
            FindObjectOfType<Fail>().DishFailed();
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            sprite.sprite = failedPlate;
            FindObjectOfType<Chef>().Angry();
        }
        else
        {
            audioSource.PlayOneShot(failedClip);

        }
        fade = true;


    }

    private void ResetPlate()
    {
        dishLayout.ResetAllIngredients();
    }
    public void Update()
    {
        if (fade)
        {
            fadetime -= Time.deltaTime;
            if (fadetime > 0)
            {
                SpriteRenderer sprite = GetComponent<SpriteRenderer>();
                Color c = sprite.color;
                float alpha = fadetime;
                c.a = alpha;
                sprite.color = c;
            }
            else
            {
                fadetime = 1.0f;
                fade = false;
                NewOrder();
            }
        }

    }
    private void NewOrder()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = plate;
        sprite.color = Color.white;
        ResetPlate();

        FindObjectOfType<Orders>().GetNewOrder();
    }
}
