using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PuppetJump.Objs
{
    public class SaveTest : MonoBehaviour
    {
        public Text moneyText;
        public GameManager gm;

        // Update is called once per frame
        void Update()
        {
            moneyText.text = "Total Money: " + gm.totalGameGold + "\n" + "Total Stars: " + gm.totalGameStars;
        }
    }
}
