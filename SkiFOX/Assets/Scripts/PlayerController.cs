using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    SurfaceEffector2D SFEF2D;
    [SerializeField] float torqueAmount = 2f;
    Rigidbody2D rgbd2d;
    [SerializeField] float jump = 50f;
    [SerializeField] AudioClip jumpSFX;
    bool canDash;
    [SerializeField] AudioClip dashSFX;
    [SerializeField] float coolDown = 2f;
    static bool isGrounded;
    [SerializeField] ParticleSystem skiEffectTrigger;
    void Start()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        canDash = true;
        SFEF2D = FindObjectOfType<SurfaceEffector2D>();
    }

    void OnCollisionStay2D(Collision2D other) {
            if(other.gameObject.tag == "LevelGround"){
                isGrounded = true;
            }
    }
    void OnCollisionExit2D(Collision2D other)
    {
            if(other.gameObject.tag == "LevelGround"){
                isGrounded = false;
            }
    }
    void Update()
    {
        foxRotate();
        DashAction();
        if(Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rgbd2d.AddForce(new Vector2(rgbd2d.velocity.x, jump ));
            GetComponent<AudioSource>().PlayOneShot(jumpSFX);
            isGrounded = false;
        }
        triggerSkiEffect();
        
    }
    void triggerSkiEffect(){
        if(isGrounded){
            skiEffectTrigger.Play();
        }
        
    }
    void foxRotate(){
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rgbd2d.AddTorque(torqueAmount);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            rgbd2d.AddTorque(-torqueAmount);
        }
    }
    void DashAction(){
        if(Input.GetKey(KeyCode.UpArrow) && canDash && isGrounded)
        {
            SFEF2D.speed = 40f;
            GetComponent<AudioSource>().PlayOneShot(dashSFX);
            canDash = false;
            Invoke("canDashAgain", coolDown);
        }
    }
    void canDashAgain(){
        SFEF2D.speed = 25f;
        canDash = true;
    }
    
}
