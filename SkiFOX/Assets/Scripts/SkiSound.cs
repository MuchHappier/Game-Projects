using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkiSound : MonoBehaviour
{
    [SerializeField] AudioClip skiSoundSFX;
    bool soundCD ;
    void Start()
    {
        soundCD = true;
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "LevelGround" && soundCD){
            GetComponent<AudioSource>().PlayOneShot(skiSoundSFX);
            soundCD = false;
            Invoke("canPlaySound", 0.15f);
        }
    }
    
    void canPlaySound(){
        soundCD = true;
    }
}
