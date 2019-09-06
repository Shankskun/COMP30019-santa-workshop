using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Packaged : MonoBehaviour
{
    public ParticleSystem particleType;

    // fully packaged, now destroy anything in its path
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pickable")
        {
            var pos = collision.transform.position;

            ParticleSystem particle = Instantiate<ParticleSystem>(particleType);
            particle.transform.position = new Vector3(pos.x, pos.y, pos.z);

            // play the particle system
            particle.Play();

            // detroy the item
            Destroy(collision.gameObject);
        }
    }
}
