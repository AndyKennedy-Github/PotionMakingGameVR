using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PuppetJump.Objs;
using PuppetJump.Beta;

namespace PuppetJump.Utils
{
    public class PuppetHand : MonoBehaviour
    {
        public enum Types { rightHandVR, leftHandVR, other };
        public Types type;
        public PuppetString puppetString;       // the PuppetString this PuppetHand is attached to
        [ReadOnly]
        public Rigidbody rigidbody;
        [ReadOnly]
        public GameObject touchedObject;        // an object being touched
        [ReadOnly]
        public GameObject grabbedObject;        // an object being grabbed
        public bool grabAllConnected = false;   // true allows a grab to grab an entire stack of connected connectables
        [HideInInspector]
        public float originalMass;
        

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
            originalMass = rigidbody.mass;
        }

        private void OnCollisionEnter(Collision collision)
        {
            int contactNum = collision.contactCount;
            for (int c = 0; c < contactNum; c++)
            {
                if (collision.GetContact(c).otherCollider.gameObject.GetComponent<Touchable>() && grabbedObject == null)
                {
                    AssignTouch(collision.GetContact(c).otherCollider.gameObject.GetComponent<Collider>());
                }
            }
        }

        private void OnCollisionStay(Collision collision)
        {
            if (touchedObject == null)
            {
                int contactNum = collision.contactCount;
                for (int c = 0; c < contactNum; c++)
                {
                    if (collision.GetContact(c).otherCollider.gameObject.GetComponent<Touchable>() && grabbedObject == null)
                    {
                        AssignTouch(collision.GetContact(c).otherCollider.gameObject.GetComponent<Collider>());
                    }
                }
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (touchedObject != null)
            {
                EndTouch();
            }
        }

        /// <summary>
        /// Checks if a collision results in the defining of a touchedObject.
        /// </summary>
        /// <param name="other"></param>
        public void AssignTouch(Collider other)
        {
            // if the object collided with is a Touchable object 
            if (other.gameObject.GetComponent<Touchable>())
            {
                // is it currently touchable
                if (other.gameObject.GetComponent<Touchable>().isTouchable)
                {
                    // if there is already a touchedObject and it's different that the new collision
                    if (touchedObject != null && touchedObject != other.gameObject)
                    {
                        // tell the previous touchedObject to not be
                        EndTouch();
                    }

                    // new collision becomes the touched object
                    touchedObject = other.gameObject;
                }
            }

            // if we have a touchedObject
            if (touchedObject != null)
            {
                // pass the PuppetHand doing the touching to the object
                touchedObject.GetComponent<Touchable>().puppetHandTouching = this;
                // indicate the object is being touched 
                touchedObject.GetComponent<Touchable>().Touch();
            }
        }

        /// <summary>
        /// Ends the touch of a touchedObject.
        /// </summary>
        public void EndTouch()
        {
            if (touchedObject != null)
            {
                // tell the object no PuppetHand is touching it
                touchedObject.GetComponent<Touchable>().puppetHandTouching = null;
                // indicate the object is not being touched
                touchedObject.GetComponent<Touchable>().Untouch();
            }

            // clear the touchObject
            touchedObject = null;
        }

        /// <summary>
        /// Initiates a grab on a grabbable object.
        /// </summary>
        public void Grab()
        {
            // if no object is currently grabbed
            if (grabbedObject == null)
            {
                // if an object touched is grabbable
                if (touchedObject != null && touchedObject.GetComponent<Grabbable>() && touchedObject.GetComponent<Grabbable>().isGrabbable)
                {
                    grabbedObject = touchedObject;
                }

                // if set to grab and entire stack of connected connectables
                if (grabAllConnected)
                {
                    if (touchedObject != null && touchedObject.GetComponent<Connectable>())
                    {
                        // search up through the hierarchy for a parent that is grabbable
                        GameObject grabbableAncestor = PuppetJumpManager.Instance.GetGrabbableAncestor(touchedObject.GetComponent<Connectable>().transform.gameObject);
                        if (grabbableAncestor != null)
                        {
                            grabbedObject = grabbableAncestor;
                        }
                    }
                }
            }

            if (grabbedObject != null)
            {
                grabbedObject.GetComponent<Grabbable>().SetAsGrabbed(this);
            }
        }

        /// <summary>
        /// Initiates the release of a grabbed object.
        /// </summary>
        public void Release()
        {
            if (grabbedObject != null)
            {
                grabbedObject.GetComponent<Grabbable>().Release(this);
            }
        }
    }
}
