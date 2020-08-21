using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PuppetJump.Objs
{
    public class Furnace : MonoBehaviour
    {
        public PotionManager pm;
        public int woodHeat = 25;
        // Start is called before the first frame update
        void Start()
        {
            pm = FindObjectOfType<PotionManager>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Wood")
            {
                pm.AddHeat(woodHeat);
                Destroy(other.gameObject);
            }
        }
    }
}
