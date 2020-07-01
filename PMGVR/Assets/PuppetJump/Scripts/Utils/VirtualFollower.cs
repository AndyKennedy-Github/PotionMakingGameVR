using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PuppetJump;

namespace PuppetJump.Utils
{
    /// <summary>
    /// Follows an enabled VR devices at it's local position.
    /// Connect physical representations, or other interaction controls, to it's fixed joint.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(FixedJoint))]
    public class VirtualFollower : MonoBehaviour
    {
        public enum InputDevices { Head, LeftHand, RightHand };
        public InputDevices inputDevice;
        public bool following = true;

        private void Start()
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.isKinematic = true;
        }

        private void FixedUpdate()
        {
            if (following)
            {
                switch (inputDevice)
                {
                    case InputDevices.Head:
                        if (PuppetJumpManager.Instance.cameraRig.cam != null)
                        {
                            transform.localPosition = PuppetJumpManager.Instance.cameraRig.cam.transform.localPosition;
                            transform.localRotation = PuppetJumpManager.Instance.cameraRig.cam.transform.localRotation;
                        }
                        break;
                    case InputDevices.LeftHand:
                        if (PuppetJumpManager.Instance.leftHandVRInputDevice != null)
                        {
                            transform.localPosition = PuppetJumpManager.Instance.leftHandVRInputDevice.transform.localPosition;
                            transform.localRotation = PuppetJumpManager.Instance.leftHandVRInputDevice.transform.localRotation;
                        }
                        break;
                    case InputDevices.RightHand:
                        if (PuppetJumpManager.Instance.rightHandVRInputDevice != null)
                        {
                            transform.localPosition = PuppetJumpManager.Instance.rightHandVRInputDevice.transform.localPosition;
                            transform.localRotation = PuppetJumpManager.Instance.rightHandVRInputDevice.transform.localRotation;
                        }
                        break;
                }
            }
        }
    }
}
