using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PuppetJump.Utils;

namespace PuppetJump.Objs
{
    public class BuyObject : MonoBehaviour
    {
        public GameManager gm;
        private Touchable touch;
        public int item;
        // Start is called before the first frame update
        void Start()
        {
            touch = this.transform.GetComponent<Touchable>();
        }

        // Update is called once per frame
        void Update()
        {
            if (gm.itemUnlocks[item] == true)
            {
                touch.isTouchable = false;
            }
        }
    }
}

