using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    private string potionName, colorAdj, color, propAdj, prop;
    int colorIntensity;
    int propertyIntensity;
    public enum Color {Blue, Red, Yellow, Purple, Green, Orange, Brown, Null};
    public enum Property {Acidic, Explosive, Freezing, Flammable, Null};

    Color myColor = Color.Null;

    Property myProperty = Property.Null;


    // Start is called before the first frame update
    void Start()
    {
        if(potionName == null)
        {
            potionName = "NULL";
        }
    }

    public void SetPotionName(string s)
    {
        potionName = s;
    }

    public void SetPotionColor(string s)
    {
        switch (s)
        {
            case "Blue":
                myColor = Color.Blue;
                break;
            case "Red":
                myColor = Color.Red;
                break;
            case "Yellow":
                myColor = Color.Yellow;
                break;
            case "Purple":
                myColor = Color.Purple;
                break;
            case "Green":
                myColor = Color.Green;
                break;
            case "Orange":
                myColor = Color.Orange;
                break;
            case "Brown":
                myColor = Color.Brown;
                break;
            case "Null":
                myColor = Color.Null;
                break;
        }
    }

    public void SetPotionColor(Color c)
    {
        switch (c)
        {
            case Color.Blue:
                myColor = Color.Blue;
                break;
            case Color.Red:
                myColor = Color.Red;
                break;
            case Color.Yellow:
                myColor = Color.Yellow;
                break;
            case Color.Purple:
                myColor = Color.Purple;
                break;
            case Color.Green:
                myColor = Color.Green;
                break;
            case Color.Orange:
                myColor = Color.Orange;
                break;
            case Color.Brown:
                myColor = Color.Brown;
                break;
            case Color.Null:
                myColor = Color.Null;
                break;
        }
    }

    public void SetPotionProperty(string s)
    {
        switch (s)
        {
            case "Acidic":
                myProperty = Property.Acidic;
                break;
            case "Explosive":
                myProperty = Property.Explosive;
                break;
            case "Freezing":
                myProperty = Property.Freezing;
                break;
            case "Flamable":
                myProperty = Property.Flammable;
                break;
            case "Null":
                myProperty = Property.Null;
                break;
        }
    }

    public void SetPotionProperyIntensity(int i)
    {
        propertyIntensity = i;
    }

    public void SetPotionColorIntensity(int i)
    {
        colorIntensity = i;
    }

    public int GetPotionProperyIntensity()
    {
        return propertyIntensity;
    }

    public int GetPotionColorIntensity()
    {
        return colorIntensity;
    }

    public void SetPotionProperty(Property p)
    {
        switch (p)
        {
            case Property.Acidic:
                myProperty = Property.Acidic;
                break;
            case Property.Explosive:
                myProperty = Property.Explosive;
                break;
            case Property.Freezing:
                myProperty = Property.Freezing;
                break;
            case Property.Flammable:
                myProperty = Property.Flammable;
                break;
            case Property.Null:
                myProperty = Property.Null;
                break;
        }
    }

    public string GetPotionName()
    {
        switch (GetPotionColorIntensity())
        {
            case 0:
                break;
            case 1:
                colorAdj = "Light ";
                break;
            case 2:
                colorAdj = "Medium ";
                break;
            case 3:
                colorAdj = "Deep ";
                break;
        }
        switch(GetPotionColor())
        {
            case Color.Blue:
                color = "Blue ";
                break;
            case Color.Red:
                color = "Red ";
                break;
            case Color.Yellow:
                color = "Yellow ";
                break;
            case Color.Purple:
                color = "Purple ";
                break;
            case Color.Green:
                color = "Green ";
                break;
            case Color.Orange:
                color = "Orange ";
                break;
            case Color.Null:
                color = "Clear ";
                break;
        }
        switch(GetPotionProperyIntensity())
        {
            case 0:
                break;
            case 1:
                propAdj = "Weak ";
                break;
            case 2:
                propAdj = "Moderate ";
                break;
            case 3:
                propAdj = "Strong ";
                break;
        }
        switch(GetPotionProperty())
        {
            case Property.Acidic:
                prop = "Acidic ";
                break;
            case Property.Explosive:
                prop = "Explosive ";
                break;
            case Property.Freezing:
                prop = "Freezing ";
                break;
            case Property.Flammable:
                prop = "Flamable ";
                break;
            case Property.Null:
                prop = "Effectless ";
                break;
        }
        return colorAdj + color + propAdj + prop;
    }

    public Color GetPotionColor()
    {
        return myColor;
    }

    public Property GetPotionProperty()
    {
        return myProperty;
    }
}
