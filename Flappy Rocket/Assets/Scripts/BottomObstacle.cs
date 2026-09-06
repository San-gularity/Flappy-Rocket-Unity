using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomObstacle : MonoBehaviour
{
    private Rigidbody2D rb;

    public GameOverScreen gameOver;
    public new AudioPart audio;

    [SerializeField] private float speed = 3f;
    [SerializeField] private float deadZone = -15f;

    private bool death = false;
    private bool pause = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if(!death && pause)
        {
            // Was Input.touchCount > 0, which is never true in a desktop
            // browser — obstacles never un-paused, so they sat at x=36.7
            // off-screen and the game looked empty.
            if(PlayerControl2.RunStarted)
            {
                StartGame();
            }
        }
        if(!death && !pause)
        {
            Movement();
        }
        else
        {
            
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerControl2 playerControl = collision.gameObject.GetComponent<PlayerControl2>();

            playerControl.SetPlayerdeath();
            SetTerrainDeath();

            //audio.Play("ExplosionSound");

            gameOver = GameObject.FindObjectOfType(typeof(GameOverScreen)) as GameOverScreen;
            gameOver.GameOverPart();
        }
    }

    private  void Movement()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);

        if (rb.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }

    public void SetTerrainDeath()
    {
        death = true;
    }

    public void StartGame()
    {
        pause = false;
    }

}
