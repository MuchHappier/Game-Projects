using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLineTrigger : MonoBehaviour
{
    [SerializeField] ParticleSystem finishEffect, finishEffect2;
    [SerializeField] float delayTime = 0.5f;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            finishEffect.Play();
            finishEffect2.Play();
            GetComponent<AudioSource>().Play();
            Invoke("menuLoad", delayTime);    
        }
    }
    void menuLoad(){
        Time.timeScale = 0f;
        SceneManager.LoadScene("Main menu");
    }
}
