using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    private string potionName;
    public enum Color { Blue, Red, Yellow, Purple, Green, Orange, Null };
    public enum Property { Acidic, Explosive, Freezing, Flammable, Null };

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

    // Update is called once per frame
    void Update()
    {

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
            case "Null":
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
            case Color.Null:
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
                break;
        }
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
                break;
        }
    }

    public string GetPotionName()
    {
        return potionName;
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
