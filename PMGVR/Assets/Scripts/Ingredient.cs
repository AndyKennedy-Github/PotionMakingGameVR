using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    // Start is called before the first frame update
    public string matName;
    public int intensity;
    public enum Color { Blue, Red, Yellow, Purple, Green, Orange, Null };
    public enum Property { Acidic, Explosive, Freezing, Flammable, Null };

    public Color myColor = Color.Null;

    public Property myProperty = Property.Null;
    void Start()
    {
        if(matName == null)
        {
            matName = "NULL";
        }
    }

    public void SetMatName(string s)
    {
        matName = s;
    }

    public string GetMatName()
    {
        return matName;
    }

    public Color GetIngredientColor()
    {
        return myColor;
    }

    public Property GetIngredientProperty()
    {
        return myProperty;
    }

    public int GetIntensity()
    {
        return intensity;
    }
}
