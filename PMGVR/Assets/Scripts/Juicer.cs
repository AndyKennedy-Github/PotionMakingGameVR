using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PuppetJump.Objs
{
    public class Juicer : MonoBehaviour
    {
        public Transform exit;
        public GameObject juiced, currentItem;
        public Ingredient ingred;
        public int juiceTime;

        private void Start()
        {
            if (juiced == null)
            {
                return;
            }

        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Juiceable"))
            {
                StartCoroutine(Juice());
                currentItem = other.gameObject;
            }
            ingred = currentItem.GetComponent<Ingredient>();
        }

        IEnumerator Juice()
        {
            yield return new WaitForSecondsRealtime(juiceTime);
            //During this time play an animation of the fruit going in to the juicer
            GameObject juice = Instantiate(juiced, exit.position, Quaternion.identity);
            Debug.Log(ingred.GetIngredientColor().ToString());
            juice.GetComponent<Ingredient>().SetColor(ingred.GetIngredientColor().ToString());
            juice.GetComponent<Ingredient>().SetProperty(ingred.GetIngredientProperty().ToString());
            juice.GetComponent<Ingredient>().SetColIntensity(ingred.GetColIntensity());
            juice.GetComponent<Ingredient>().SetPropIntensity(ingred.GetPropIntensity());
            Destroy(currentItem);
            StopCoroutine(Juice());
        }
    }
}

