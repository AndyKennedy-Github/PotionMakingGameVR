using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceToPosition : MonoBehaviour
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
        if(rigidbody != null)
        {
            Vector3 Pdes = target.position;
            Vector3 Vdes = Vector3.zero;

            float massDamp = damping;
            if (massEffectsDamping)
            {
                massDamp *= rigidbody.mass;
            }

            float kp = (6f * frequency) * (6f * frequency) * 0.25f;
            float kd = 4.5f * frequency * massDamp;

            float dt = Time.fixedDeltaTime;
            float g = 1 / (1 + kd * dt + kp * dt * dt);
            float ksg = kp * g;
            float kdg = (kd + kp * dt) * g;
            Vector3 Pt0 = transform.position;
            Vector3 Vt0 = rigidbody.velocity;
            Vector3 F = (Pdes - Pt0) * ksg + (Vdes - Vt0) * kdg;
            rigidbody.AddForce(F);
        }
        
    }
}
