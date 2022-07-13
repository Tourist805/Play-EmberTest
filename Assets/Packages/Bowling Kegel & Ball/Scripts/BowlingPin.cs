using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPin : MonoBehaviour
{
    [SerializeField] private float _power = 3.0f, _radius = 5.0f, _upForce = 1.0f;
    [SerializeField] private LayerMask _layerMask;
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.TryGetComponent(out Ball ball))
        {
            Vector3 explosionPosition = this.transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPosition, _radius, _layerMask);

            foreach (Collider c in colliders)
            {
                Rigidbody rigidbody = c.GetComponent<Rigidbody>();
                if (rigidbody != null)
                {
                    rigidbody.AddExplosionForce(_power, explosionPosition, _radius, _upForce, ForceMode.Impulse);
                }

            }
        }
        else
        {
            // Collect Points
            Coin.AddPoints();
        }
        
    }
}
