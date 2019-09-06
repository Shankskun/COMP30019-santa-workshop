using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBox : MonoBehaviour {

    // new boxes (further stages in the assembly line)
    public GameObject box;
    public GameObject gift1;
    public GameObject gift2;
    public GameObject gift3;
    public float offset = 0.2f;

    // item in collision with box
    private GameObject item;
    private bool acceptItem;

    // Item names to be collected in order
    public string firstObjectName;
    public string secondObjectName;

    // particle system for wrong items
    public ParticleSystem poof_particle;
    private const float MAXTIME = 2.0f;

    // Update score
    private Scoring score;

    private void Start()
    {
        score = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<Scoring>();
    }

    // when box is in collision with gift item
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Pickable")
        {           
            acceptItem = true;
            item = collision.gameObject;
        }
    }

    // change box state when tasks are completed
    void Update()
    {
        if (acceptItem)
        {
            // if it's an open box (stage 1)
            if (this.gameObject.tag == "emptyBox")
            {
                // correct item
                if ( item.name == firstObjectName)
                {
                    Destroy(item);
                    // Update box
                    ReplaceBox(box);
                    // Increment score
                    score.addScore();
                } else
                {
                    // Wrong order; destroy item
                    MakeItDisappear();
                    Destroy(item);
                    // Decrement score
                    score.minusScore();
                }

            }

            // if it's a closed box (stage 2)
            else
            {
                // correct item
                if (item.name == secondObjectName)
                {
                    Destroy(item);
                    score.addScore();

                    // creates a random prefab giftbox
                    int i = Random.Range(1, 3);

                    switch (i)
                    {
                        case 1:
                            ReplaceBox(gift1);
                            break;
                        case 2:
                            ReplaceBox(gift2);
                            break;
                        case 3:
                            ReplaceBox(gift3);
                            break;
                    }
                } else
                {
                    // Wrong order; destroy item
                    MakeItDisappear();
                    Destroy(item);
                    // Decrement score
                    score.minusScore();
                }
                
            }
            acceptItem = false;
        }
    }

    // replace with later stages of box
    void ReplaceBox(GameObject o)
    {
        // get location of box currently
        var position = this.gameObject.transform.position;

        // destroy old box
        Destroy(this.gameObject);

        // replace old box with new "closed" box 
        GameObject newBox = Instantiate<GameObject>(o);

        // place gift box slightly upward, due to different sizes
        if (item.name != firstObjectName)
        {
            newBox.transform.position = new Vector3(position.x, position.y + offset, position.z);
        }
        // place the new box at the same location
        else
        {
            newBox.transform.position = new Vector3(position.x, position.y, position.z);
        }
    }

    public void MakeItDisappear()
    {
        SantaWarning.WhenWrongItem();

        ParticleSystem particle = Instantiate<ParticleSystem>(poof_particle);
        particle.transform.position = transform.position;

        particle.Play();
    }
}
