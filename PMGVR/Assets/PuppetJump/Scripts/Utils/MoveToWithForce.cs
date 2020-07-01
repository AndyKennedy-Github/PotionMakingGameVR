using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PuppetJump;

namespace PuppetJump.Utils
{

    /// <summary>
    /// Moves a RigidBody object to a target position by adding force.
    /// </summary>

    [RequireComponent(typeof(Rigidbody))]
    public class MoveToWithForce : MonoBehaviour
    {
        [HideInInspector]
        public Rigidbody rigidbody;
        public Transform target;
        [System.Serializable]
        public class Settings
        {
            public float toVel = 2.5f;
            public float maxVel = 15.0f;
            public float maxForce = 40.0f;
            public float gain = 5f;
            public bool rotateWithTarget = true;
        }
        public Settings settings;


        [System.Serializable]
        public class PIDController
        {

            [Tooltip("Proportional constant (counters current error)")]
            public float Kp = 0.2f;

            [Tooltip("Integral constant (counters cumulated error)")]
            public float Ki = 0.05f;

            [Tooltip("Derivative constant (fights oscillation)")]
            public float Kd = 1f;

            [Tooltip("Current control value")]
            public float value = 0;

            private float lastError;
            private float integral;

            /// 
            /// Update our value, based on the given error.  We assume here that the
            /// last update was Time.deltaTime seconds ago.
            /// 
            /// <param name="error" />Difference between current and desired outcome.
            /// Updated control value.
            public float Update(float error)
            {
                return Update(error, Time.deltaTime);
            }

            /// 
            /// Update our value, based on the given error, which was last updated
            /// dt seconds ago.
            /// 
            /// <param name="error" />Difference between current and desired outcome.
            /// <param name="dt" />Time step.
            /// Updated control value.
            public float Update(float error, float dt)
            {
                float derivative = (error - lastError) / dt;
                integral += error * dt;
                lastError = error;

                value = Mathf.Clamp01(Kp * error + Ki * integral + Kd * derivative);
                return value;
            }
        }
        public PIDController posController;


        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (settings.rotateWithTarget)
            {
                transform.rotation = target.rotation;
            }
        }

        private void FixedUpdate()
        {

            Vector3 dist = target.position - transform.position;
            Vector3 tgtVel = Vector3.ClampMagnitude(settings.toVel * dist, settings.maxVel);
            Vector3 error = tgtVel - rigidbody.velocity;
            Vector3 force = Vector3.ClampMagnitude(settings.gain * error, settings.maxForce);
            rigidbody.AddForce(force, ForceMode.Impulse);


            /*
            Vector3 curPos = transform.position;
            Vector3 err = target.position - curPos;

            Vector3 newForce;
            newForce.x = posController.Update(err.x);
            newForce.y = posController.Update(err.y);
            newForce.z = posController.Update(err.z);
            rigidbody.AddForce(newForce, ForceMode.Impulse);
            */
            
            /*
            Vector3 dist = target.position - transform.position;
            Vector3 tgtVel = Vector3.ClampMagnitude(settings.toVel * dist, settings.maxVel);
            Vector3 error = tgtVel - rigidbody.velocity;
            error.x = posController.Update(error.x);
            error.y = posController.Update(error.y);
            error.z = posController.Update(error.z);
            Vector3 force = Vector3.ClampMagnitude(settings.gain * error, settings.maxForce);
            rigidbody.AddForce(force, ForceMode.Impulse);
            */



        }
    }
}
