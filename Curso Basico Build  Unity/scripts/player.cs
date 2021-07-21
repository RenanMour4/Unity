using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    
    public float startTime = 4f;

    
    private Rigidbody rb;

    private Animator animator;

    private AudioSource audioSource;
    public AudioClip pickupSfx, deathSfx;

    private bool isDead = true;

    void Start(){
        rb = GetComponent<Rigidbody>();

        animator = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();
        Invoke("setIsDead", startTime); 
    } 

    void setIsDead()
    {
        isDead = false;
    }

    private void FixedUpdate()
    {
        if (isDead){
            return;
        }
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(horizontal != 0 || vertical != 0)
        {
            animator.SetBool("Run", true);
        }else{
            animator.SetBool("Run", false);
        }

        Vector3 movement = new Vector3(horizontal, 0, vertical);

        if(movement != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(movement);

        //rb.AddForce(movement * speed);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup")){



            LevelControler.instance.setPickups();
            Destroy(other.gameObject);
            PlayAudio(pickupSfx);
        
        }
        else if(other.CompareTag("Enemy"))
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        animator.SetTrigger("Death");

        PlayAudio(deathSfx);
        Invoke("ReloadScene", 3f);
    }

    void PlayAudio(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    void ReloadScene()
    {
            SceneController.instance.ReloadScene();
    }
}
