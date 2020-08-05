using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionManager : MonoBehaviour
{
    Potion potionInPot;
    
    public float heatIndex;
    public bool isHot;
    public Text potionText, heatText;
    void Start()
    {
        if (potionInPot == null)
        {
            potionInPot = GetComponentInChildren<Potion>();
        }
        RevertPotion();
        ClearHeat();
    }

    void Update()
    {
        if (heatIndex < 0)
        {
           if( isHot == true)
           {
                isHot = false;
           }
            heatIndex = 0;
            heatText.text = "Current Heat Level: 0" + "\n" + "I'm Cold!";
        }
        else if(heatIndex >= 100)
        {
            if(isHot == false)
            {
                isHot = true;
            }
            heatIndex = 100;
            heatText.text = "Current Heat Level: 100" + "\n" + "I'm Hot!";
        }
        else
        {
            if(isHot)
            {
                heatText.text = "Current Heat Level: " + heatIndex + "\n" + "I'm Hot!";
            }
            else if(!isHot)
            {
                heatText.text = "Current Heat Level: " + heatIndex + "\n" + "I'm Cold!";
            }
            
        }
        heatIndex -= Time.deltaTime;
        potionText.text = "Potion in the Pot:" + "\n" + potionInPot.GetPotionName();
    }

    public void RevertPotion()
    {
        if(potionInPot != null)
        {
            potionInPot.SetPotionColor("Null");
            potionInPot.SetPotionProperty("Null");
            potionInPot.SetPotionColorIntensity(0);
            potionInPot.SetPotionProperyIntensity(0);
        }
    }

    public void RevertPotion(Potion p)
    {
        p.SetPotionColor("Null");
        p.SetPotionProperty("Null");
        p.SetPotionColorIntensity(0);
        p.SetPotionProperyIntensity(0);
    }

    void AddIngredientToPotion(GameObject g)
    {
        if(g.GetComponent<Ingredient>().GetIngredientColor() != Ingredient.Color.Null || g.GetComponent<Ingredient>().GetIngredientColor().ToString() == potionInPot.GetPotionColor().ToString())
        {
            if(potionInPot.GetPotionColorIntensity() < 3)
            {
                potionInPot.SetPotionColor(g.GetComponent<Ingredient>().GetIngredientColor().ToString());
                potionInPot.SetPotionColorIntensity(potionInPot.GetPotionColorIntensity() + g.GetComponent<Ingredient>().GetColIntensity());
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
                potionInPot.SetPotionProperyIntensity(potionInPot.GetPotionProperyIntensity() + g.GetComponent<Ingredient>().GetPropIntensity());
            }
        }
    }

    void CreateColorCombo(GameObject g)
    {
        if(g.GetComponent<Potion>().GetPotionColorIntensity() == 1)
        {
            if (potionInPot.GetPotionColor() == Potion.Color.Blue && g.GetComponent<Ingredient>().GetIngredientColor() == Ingredient.Color.Red)
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
        }
        if (g.GetComponent<Potion>().GetPotionColorIntensity() == 2)
        {
            if (potionInPot.GetPotionColor() == Potion.Color.Orange || potionInPot.GetPotionColor() == Potion.Color.Purple || potionInPot.GetPotionColor() == Potion.Color.Green && g.GetComponent<Ingredient>().GetIngredientColor() == Ingredient.Color.Red || g.GetComponent<Ingredient>().GetIngredientColor() == Ingredient.Color.Blue || g.GetComponent<Ingredient>().GetIngredientColor() == Ingredient.Color.Yellow)
            {
                potionInPot.SetPotionColor("Brown");
                potionInPot.SetPotionColorIntensity(3);
            }
        }
    }

    public void AddHeat(float f)
    {
        heatIndex += f;
    }

    public void ClearHeat()
    {
        heatIndex = 0;
        isHot = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ingredient" && isHot)
        {
            AddIngredientToPotion(other.gameObject);
            Destroy(other.gameObject);
        }
        else if(other.tag == "Ingredient" && !isHot)
        {
            //animation stuff
            //floating ingredients
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

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ingredient" && isHot)
        {
            AddIngredientToPotion(other.gameObject);
            Destroy(other.gameObject);
        }
    }
}
