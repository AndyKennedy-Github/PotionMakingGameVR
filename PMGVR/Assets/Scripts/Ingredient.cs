using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PuppetJump.Objs
{
    public class Ingredient : MonoBehaviour
    {
        // Start is called before the first frame update
        public string matName;
        public int colIntensity;
        public int propIntensity;
        public bool isInBox = true;
        private Grabbable grabbed;

        public enum Color { Blue, Red, Yellow, Purple, Green, Orange, Null };
        public enum Property { Acidic, Explosive, Freezing, Flammable, Null };

        public Color myColor = Color.Null;

        public Property myProperty = Property.Null;
        void Start()
        {
            grabbed = GetComponent<Grabbable>();
            if (matName == null)
            {
                matName = "NULL";
            }
        }

        void Update()
        {
            DestroySelf();
        }

        public void SetMatName(string s)
        {
            matName = s;
        }

        public void SetProperty(string s)
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

        public void SetColor(string s)
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
                    myColor = Color.Null;
                    break;
            }
        }

        public void SetColIntensity(int i)
        {
            colIntensity = i;
        }

        public void SetPropIntensity(int i)
        {
            propIntensity = i;
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

        public int GetColIntensity()
        {
            return colIntensity;
        }

        public int GetPropIntensity()
        {
            return propIntensity;
        }

        public void DestroySelf()
        {
            if (!grabbed.isGrabbed && !isInBox)
            {
                StartCoroutine(DestroyObj(this.gameObject));
            }
            else if (grabbed.isGrabbed)
            {
                StopCoroutine(DestroyObj(this.gameObject));
            }
        }

        IEnumerator DestroyObj(GameObject g)
        {
            yield return new WaitForSeconds(3);
            Destroy(g);
        }
    }
}