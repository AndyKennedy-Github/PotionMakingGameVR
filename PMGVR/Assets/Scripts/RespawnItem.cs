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
        public List<GameObject> children = new List<GameObject>();


        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(itemTag))
            {
                grabbed = other.transform.GetComponent<Grabbable>();
                respawnCube = new Vector3(Random.Range(transform.position.x - .15f, transform.position.x + .15f), transform.position.y, Random.Range(transform.position.z - .15f, transform.position.z + .15f));
                StartCoroutine(ReplaceItem(other.gameObject));
                other.transform.GetComponent<Ingredient>().isInBox = false;
            }
        }

        IEnumerator ReplaceItem(GameObject g)
        {
            foreach (GameObject kid in children)
            {
                if (kid == null)
                {
                    children.Remove(kid);
                }
            }
            yield return new WaitForSeconds(3);
            if(children.Count < 3)
            {
                GameObject newkid = Instantiate(respawnItem, respawnCube, Quaternion.identity);
                children.Add(newkid);
            }

            StopCoroutine("ReplaceItem");
        }
    }
}

