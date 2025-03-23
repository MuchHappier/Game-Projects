using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireworkTrigger : MonoBehaviour
{
    static int scoreCount;
    [SerializeField] ParticleSystem firework;
    void Start()
    {
        scoreCount = 0;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            scoreCount += 1;
            firework.Play();
            Destroy(gameObject, 0f);
        }
    }
}
