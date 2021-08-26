using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl2 : MonoBehaviour
{
    private Rigidbody2D rb;

    public ParticleSystem exhaust;
    public ParticleSystem exhaustExtra;
    public ParticleSystem explosion;

    [SerializeField] private float thrust = 5f;
    //[SerializeField] private float falling = 5f;
    [SerializeField] private float frontFalling = 1f;

    private bool death = false;
    private bool once = false;
    private bool pause = true;

    public new AudioPart audio;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(!death && pause)
        {
            CreateExhaust();
            rb.isKinematic = true;
            if(Input.touchCount > 0)
            {
                StartGame();
            }
        }
        if(!death && !pause)
        {
            Movement();
        }
        else if(death)
        {
            //PlayerDeath();
            rb.velocity = new Vector2(frontFalling , rb.velocity.y);
        }
    }

    private void Movement()
    {
        //float vDirection = Input.GetAxisRaw("Vertical");
        float ang = Mathf.Atan2(rb.velocity.y, x: 10) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(x: 0, y: 0, z: ang - 90));
     
        if (Input.touchCount > 0) //(vDirection > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, thrust);
            CreateExhaust();
        }
    }
    void CreateExhaust()
    {
        exhaust.Play();
        exhaustExtra.Play();
    }
    void Explosion()
    {
        explosion.Play();                 //particle system
                                          //audio.Play("ExplosionSound");
    }

    public void SetPlayerdeath()
    {
        death = true;
        if(!once)
        {
            //explosion.transform = 
            Explosion();
            audio.Play("ExplosionSound");
            once = true;
            Time.timeScale = 0.3f;
        }
    }
    private void StartGame()
    {
        pause = false;
        rb.isKinematic = false;
    }

}
