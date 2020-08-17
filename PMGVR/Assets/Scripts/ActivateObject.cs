using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PuppetJump.Objs
{
    public class ActivateObject : MonoBehaviour
    {
        public OutfitManager om;
        public GameManager gm;
        public int item;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Activate()
        {
            if (gm.itemUnlocks[item] == true)
            {
                if (this.gameObject.CompareTag("OutfitButton"))
                {
                    om.currentOutfit = om.outfits[item];
                    ES3.Save("Current Outfit", om.currentOutfit);
                }
                if (this.gameObject.CompareTag("ItemButton"))
                {

                }
                //enable object in scene, may be different for different types of items
            }
        }
    }
}
