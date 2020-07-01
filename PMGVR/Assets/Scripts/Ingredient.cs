using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    // Start is called before the first frame update
    public string matName;
    void Start()
    {
        if(matName == null)
        {
            matName = "NULL";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMatName(string s)
    {
        matName = s;
    }

    public string GetMatName()
    {
        return matName;
    }
}
