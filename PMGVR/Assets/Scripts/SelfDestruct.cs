using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PuppetJump.Objs
{
    public class SelfDestruct : MonoBehaviour
    {
        public bool isInBox = true;
        private Grabbable grabbed;


        void Start()
        {
            grabbed = GetComponent<Grabbable>();
        }

        void Update()
        {
            DestroySelf();
        }

        public void DestroySelf()
        {
            if (!grabbed.isGrabbed && !isInBox)
            {
                StartCoroutine(DestroyObj(this.gameObject));
            }
            else if (grabbed.isGrabbed)
            {
                StopCoroutine(DestroyObj(this.gameObject));
            }
        }

        IEnumerator DestroyObj(GameObject g)
        {
            yield return new WaitForSeconds(3);
            Destroy(g);
        }
    }
}
