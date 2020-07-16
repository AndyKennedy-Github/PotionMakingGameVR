﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionManager : MonoBehaviour
{
    public Potion potionInPot;

    void Start()
    {
        if (potionInPot == null)
        {
            potionInPot = FindObjectOfType<Potion>();
        }
        RevertPotion();
    }

    void Update()
    {
        if(potionInPot != null)
        {
            Debug.Log(potionInPot.GetPotionName());
        }

    }

    void RevertPotion()
    {
        potionInPot.SetPotionName("NULL");
        potionInPot.SetPotionColor("NULL");
        potionInPot.SetPotionProperty("NULL");
        potionInPot.SetPotionColorIntensity(0);
        potionInPot.SetPotionProperyIntensity(0);
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
        else if(potionInPot.GetPotionColor().ToString() != g.GetComponent<Ingredient>().GetIngredientColor().ToString())
        {
            CreateColorCombo(g);
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

    void CreateColorCombo(GameObject g)
    {
        if(potionInPot.GetPotionColor() == Potion.Color.Blue && g.GetComponent<Ingredient>().GetIngredientColor() == Ingredient.Color.Red)
        { 
            potionInPot.SetPotionColor("Purple");
            potionInPot.SetPotionColorIntensity(2);
        }
        if (potionInPot.GetPotionColor() == Potion.Color.Blue && g.GetComponent<Ingredient>().GetIngredientColor() == Ingredient.Color.Yellow)
        {
            potionInPot.SetPotionColor("Green");
            potionInPot.SetPotionColorIntensity(2);
        }
        if (potionInPot.GetPotionColor() == Potion.Color.Red && g.GetComponent<Ingredient>().GetIngredientColor() == Ingredient.Color.Blue)
        {
            potionInPot.SetPotionColor("Purple");
            potionInPot.SetPotionColorIntensity(2);
        }
        if (potionInPot.GetPotionColor() == Potion.Color.Red && g.GetComponent<Ingredient>().GetIngredientColor() == Ingredient.Color.Yellow)
        {
            potionInPot.SetPotionColor("Orange");
            potionInPot.SetPotionColorIntensity(2);
        }
        if (potionInPot.GetPotionColor() == Potion.Color.Yellow && g.GetComponent<Ingredient>().GetIngredientColor() == Ingredient.Color.Blue)
        {
            potionInPot.SetPotionColor("Green");
            potionInPot.SetPotionColorIntensity(2);
        }
        if (potionInPot.GetPotionColor() == Potion.Color.Yellow && g.GetComponent<Ingredient>().GetIngredientColor() == Ingredient.Color.Red)
        {
            potionInPot.SetPotionColor("Orange");
            potionInPot.SetPotionColorIntensity(2);
        }
        if(potionInPot.GetPotionColor() == Potion.Color.Orange || potionInPot.GetPotionColor() == Potion.Color.Purple || potionInPot.GetPotionColor() == Potion.Color.Green && g.GetComponent<Ingredient>().GetIngredientColor() == Ingredient.Color.Red || g.GetComponent<Ingredient>().GetIngredientColor() == Ingredient.Color.Blue || g.GetComponent<Ingredient>().GetIngredientColor() == Ingredient.Color.Yellow)
        {
            potionInPot.SetPotionColor("Brown");
            potionInPot.SetPotionColorIntensity(3);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ingredient")
        {
            AddIngredientToPotion(other.gameObject);
            Destroy(other.gameObject);
        }
        
        if(other.tag == "Bottle")
        {
            other.gameObject.transform.GetComponent<Bottle>().potionToPull = potionInPot;
            other.gameObject.transform.GetComponent<Bottle>().AddPotion();
        }

        if(other.tag == "Nullifying Powder")
        {
            RevertPotion();
            Destroy(other.gameObject);
        }
    }
}
