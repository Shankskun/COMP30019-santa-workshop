using UnityEngine;
using System.Collections;

public class Packaging : MonoBehaviour
{
    // fire particles
    public ParticleSystem fire_particle;
    public ParticleSystem magic_particle;

    private bool hasExploded;
    private bool isDropped;
    private const float MAXTIME = 2.0f;

    // Update score
    private Scoring score;

    private void Start()
    {
        score = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<Scoring>();
    }


    /* when collided with santa's sleigh or drop in floor */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Santa" || collision.gameObject.tag == "floor")
        {
            // when gift or box dropped onto floor
            if (collision.gameObject.tag == "floor")
            {
                isDropped = true;
            }

            // get location of box
            var position = this.transform.position;

            // add particle effects
            if(this.tag == "emptyBox" || this.tag == "fullBox" || isDropped == true)
            {
                // only play particle system once, and minus score once
                if (hasExploded == false)
                {
                    ParticleInitialize(position, fire_particle);
                    // notify santa (dialogue)
                    SantaWarning.WhenBoxIsBurn();
                    // shake camera
                    CameraShake.Shake();
                    // decrement score
                    score.minusScore();
                    // notify has exploded
                    hasExploded = true;
                }
            }
            else
            {
                ParticleInitialize(position, magic_particle);
            }
            // destroy box
            Destroy(this.gameObject, 0.2f);

            // reset bool
            isDropped = false;
        }
    }

    // particle explosion method
    void ParticleInitialize(Vector3 pos, ParticleSystem particleType)
    {
        ParticleSystem particle = Instantiate<ParticleSystem>(particleType);
        particle.transform.position = new Vector3(pos.x, pos.y, pos.z);

        particle.Play();
    }
}
