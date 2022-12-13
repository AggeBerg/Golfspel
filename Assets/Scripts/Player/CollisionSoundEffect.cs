using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSoundEffect : MonoBehaviour
{

    public AudioSource HitEffect;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name.Contains("Wall"))
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            HitEffect.Play();
        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "MyGameObjectTag")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Do something else here");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
