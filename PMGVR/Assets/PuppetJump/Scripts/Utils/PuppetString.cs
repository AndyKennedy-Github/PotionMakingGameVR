using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PuppetJump.Objs;

namespace PuppetJump.Utils
{
    public class PuppetString : MonoBehaviour
    {
        public PuppetHand puppetHand;           // the PuppetHand attached to this PuppetString
        [ReadOnly]
        public FixedJoint grabJointFixed;       // a fixed joint used to attach grabbed objects

        /// <summary>
        /// If a PuppetHand is grabbing an object with a FixedJoint,
        /// and the joint breaks because too much force is placed on it,
        /// this releases the grabbed object.
        /// </summary>
        void OnJointBreak()
        {
            if(puppetHand.grabbedObject != null)
            {
                if(puppetHand.grabbedObject.GetComponent<Grabbable>().grabStyle == Grabbable.GrabStyles.fixedJoint)
                {
                    puppetHand.grabbedObject.GetComponent<Grabbable>().Release(puppetHand);
                }
            }
        }
    }
}
