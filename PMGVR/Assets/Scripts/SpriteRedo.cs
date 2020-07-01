using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRedo : MonoBehaviour
{ 
    public Transform target;
    public float speed;
    bool isAlive = false;

    void Update()
    {
        if(isAlive)
        {
            SpriteMove();
        }
    }

    public void SetAlive()
    {
        isAlive = !isAlive;
    }

    void SpriteMove()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, target.localPosition, (speed * Time.deltaTime));
        if (Vector3.Distance(transform.localPosition, target.localPosition) < .001f)
        {
            target.localPosition = new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(-.75f, .75f), target.localPosition.z);
        }
    }
}
