using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    // Start is called before the first frame update

    public Potion potionToPull;

    private Potion potionInBottle;
    void Start()
    {
        potionInBottle = GetComponentInChildren<Potion>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPotion()
    {
        potionInBottle.SetPotionName(potionToPull.GetPotionName());
        potionInBottle.SetPotionColor(potionToPull.GetPotionColor());
        potionInBottle.SetPotionProperty(potionToPull.GetPotionProperty());
        Debug.Log("I have a potion in me! It's name is " + potionInBottle.GetPotionName() + "!");
    }

}
