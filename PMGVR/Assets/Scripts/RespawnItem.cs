using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PuppetJump.Objs
{
    public class RespawnItem : MonoBehaviour
    {
        public GameObject respawnItem;
        public Touchable touch;
        public string itemTag;
        private Vector3 respawnCube;


        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(itemTag))
            {
                touch = other.transform.GetComponent<Touchable>();
                respawnCube = new Vector3(Random.Range(transform.position.x - .2f, transform.position.x + .2f), transform.position.y, Random.Range(transform.position.z - .2f, transform.position.z + .2f));
                StartCoroutine(ReplaceItem(other.gameObject));
                if(touch.isTouched == false)
                {
                    StartCoroutine(DestroyObj(other.gameObject));
                }
            }
        }

        IEnumerator ReplaceItem(GameObject g)
        {
            yield return new WaitForSeconds(3);
            Instantiate(respawnItem, respawnCube, Quaternion.identity);
            StopCoroutine("ReplaceItem");
        }

        IEnumerator DestroyObj(GameObject g)
        {
            yield return new WaitForSeconds(3);
            Destroy(g);
            StopCoroutine("DestroyObj");
        }
    }
}

