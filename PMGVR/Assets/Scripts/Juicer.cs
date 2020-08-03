using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juicer : MonoBehaviour
{
    public Transform exit;
    public GameObject juiced;
    public Ingredient ingred;
    public int juiceTime;

    private void Start()
    {
        ingred = juiced.GetComponent<Ingredient>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Juiceable"))
        {
            StartCoroutine(Juice());
        }
    }

    IEnumerator Juice()
    {
        yield return new WaitForSecondsRealtime(juiceTime);
        //During this time play an animation of the fruit going in to the juicer
        GameObject juice = Instantiate(juiced, exit);
        juice.GetComponent<Ingredient>().SetColor(ingred.GetIngredientColor().ToString());
        juice.GetComponent<Ingredient>().SetProperty(ingred.GetIngredientProperty().ToString());
        juice.GetComponent<Ingredient>().SetColIntensity(ingred.GetColIntensity());
        juice.GetComponent<Ingredient>().SetPropIntensity(ingred.GetPropIntensity());
        StopCoroutine(Juice());
    }
}
