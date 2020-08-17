using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PuppetJump.Objs
{
    public class RespawnItem : MonoBehaviour
    {
        public GameObject respawnItem;
        public Grabbable grabbed;
        public string itemTag;
        private Vector3 respawnCube;


        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(itemTag))
            {
                grabbed = other.transform.GetComponent<Grabbable>();
                respawnCube = new Vector3(Random.Range(transform.position.x - .2f, transform.position.x + .2f), transform.position.y, Random.Range(transform.position.z - .2f, transform.position.z + .2f));
                StartCoroutine(ReplaceItem(other.gameObject));
                other.transform.GetComponent<Ingredient>().isInBox = false;
            }
        }

        IEnumerator ReplaceItem(GameObject g)
        {
            yield return new WaitForSeconds(3);
            Instantiate(respawnItem, respawnCube, Quaternion.identity);
            StopCoroutine("ReplaceItem");
        }
    }
}

