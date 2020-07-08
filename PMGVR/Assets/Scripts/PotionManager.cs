using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionManager : MonoBehaviour
{

    public List<Ingredient> materials;

    public Potion potionInPot;

    void Start()
    {
        if (potionInPot == null)
        {
            potionInPot = FindObjectOfType<Potion>();
        }
    }

    void Update()
    {
        if (materials.Count == 3)
        {
            MakePotion(materials[0].matName, materials[1].matName, materials[2].matName);
        }
    }

    void MakePotion(string one, string two, string three)
    {
        /*
        if (one == "Eyeball" && two == "Tail" || one == "Tail" && two == "Eyeball")
        {
            potionInPot.SetPotionName("Melty Sad Boi");
            potionInPot.SetPotionColor("Blue");
            potionInPot.SetPotionProperty("Acidic");
            Debug.Log("I made a potion! It's a " + potionInPot.GetPotionName() + "!");
        }
        else
        {
            materials.Clear();
        }
        */
    }

    void RevertPotion()
    {
        potionInPot.SetPotionName("NULL");
        potionInPot.SetPotionColor("NULL");
        potionInPot.SetPotionProperty("NULL");
        materials.Clear();
    }

    void AddIngredientToPotion(GameObject g)
    {
        if(g.GetComponent<Ingredient>().GetIngredientColor() != Ingredient.Color.Null || g.GetComponent<Ingredient>().GetIngredientColor().ToString() == potionInPot.GetPotionColor().ToString())
        {
            if(potionInPot.GetPotionColorIntensity() < 3)
            {
                potionInPot.SetPotionColor(g.GetComponent<Ingredient>().GetIngredientColor().ToString());
                potionInPot.SetPotionColorIntensity(potionInPot.GetPotionColorIntensity() + g.GetComponent<Ingredient>().GetIntensity());
            }
        }

        if(g.GetComponent<Ingredient>().GetIngredientProperty() != Ingredient.Property.Null  || g.GetComponent<Ingredient>().GetIngredientProperty().ToString() == potionInPot.GetPotionProperty().ToString())
        {
            if (potionInPot.GetPotionProperyIntensity() < 3)
            {
                potionInPot.SetPotionProperty(g.GetComponent<Ingredient>().GetIngredientProperty().ToString());
                potionInPot.SetPotionProperyIntensity(potionInPot.GetPotionProperyIntensity() + g.GetComponent<Ingredient>().GetIntensity());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ingredient" && materials.Count < 2)
        {
            /*materials.Add(other.gameObject.transform.GetComponent<Ingredient>());
            Debug.Log("I got a material! It's name is: " + other.gameObject.transform.GetComponent<Ingredient>().GetMatName());
            */
            AddIngredientToPotion(other.gameObject);
        }
        
        if(other.tag == "Bottle" && materials.Count == 2)
        {
            other.gameObject.transform.GetComponent<Bottle>().potionToPull = potionInPot;
            other.gameObject.transform.GetComponent<Bottle>().AddPotion();
        }

        if(other.tag == "Nullifying Powder")
        {
            RevertPotion();
        }
    }
}
