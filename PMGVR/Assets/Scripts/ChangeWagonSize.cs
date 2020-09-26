using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeWagonSize : MonoBehaviour
{
    public bool isBig;
    public Text sizeText;

    void Update()
    {
        if(isBig)
        {
            MakeWagonMedium();
            sizeText.text = "Big";
        }
        else
        {
            MakeWagonSmall();
            sizeText.text = "Small";
        }
    }
    public void MakeWagonSmall()
    {
        gameObject.transform.localScale = new Vector3(1,1,1);
    }

    public void MakeWagonMedium()
    {
        gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }

    public void ChangeSize()
    {
        isBig = !isBig;
    }

}
