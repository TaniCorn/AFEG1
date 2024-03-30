using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour
{
    private bool bIsDragging = false;
    [SerializeField]
    private SO_Ingredients ingrediantSO;
    [SerializeField]
    private GameObject ingrediantPrefab;
    private GameObject ingrediantInstance;

    // Update is called once per frame
    void Update()
    {
        if (bIsDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ingrediantInstance.transform.position = (mousePosition);
        }
    }

    private void OnMouseDown()
    {
        SpawnFood();
        bIsDragging = true;   
    }
    private void OnMouseUp()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        bIsDragging = false;

        //If we land on the plate
        if (ingrediantInstance != null)
        {
            Plate goal = FindObjectOfType<Plate>();
            if (goal != null)
            {
                float radius = goal.radius;
                if (mousePosition.x > -radius && mousePosition.x < radius && mousePosition.y > -radius && mousePosition.y < radius)
                {
                    goal.UseIngredient(ingrediantSO.type);
                }
            }
            Destroy(ingrediantInstance);

        }
    }

    private void SpawnFood()
    {
        ingrediantInstance = Instantiate(ingrediantPrefab);
        ingrediantInstance.GetComponent<IngredientInst>().SetIngredient(ingrediantSO);
    }

}
