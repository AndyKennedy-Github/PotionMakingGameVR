using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorqueToRotation : MonoBehaviour
{
    private Rigidbody rigidbody;
    public Transform target;
    public float frequency = 1.0f;
    public float damping = 1.0f;
    public bool massEffectsDamping = true;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (rigidbody != null)
        {
            Quaternion desiredRotation = target.rotation;

            float massDamp = damping;
            if (massEffectsDamping)
            {
                massDamp *= rigidbody.mass;
            }

            float kp = (6f * frequency) * (6f * frequency) * 0.25f;
            float kd = 4.5f * frequency * damping;
            float dt = Time.fixedDeltaTime;
            float g = 1 / (1 + kd * dt + kp * dt * dt);
            float ksg = kp * g;
            float kdg = (kd + kp * dt) * g;
            Vector3 x;
            float xMag;
            Quaternion q = desiredRotation * Quaternion.Inverse(transform.rotation);
            q.ToAngleAxis(out xMag, out x);
            x.Normalize();
            x *= Mathf.Deg2Rad;
            Vector3 pidv = kp * x * xMag - kd * rigidbody.angularVelocity;
            Quaternion rotInertia2World = rigidbody.inertiaTensorRotation * transform.rotation;
            pidv = Quaternion.Inverse(rotInertia2World) * pidv;
            pidv.Scale(rigidbody.inertiaTensor);
            pidv = rotInertia2World * pidv;
            rigidbody.AddTorque(pidv);
        }
    }
}
