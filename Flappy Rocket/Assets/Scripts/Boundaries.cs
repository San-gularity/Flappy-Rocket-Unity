using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    public GameOverScreen gameOver;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerControl2 playerControl = collision.gameObject.GetComponent<PlayerControl2>();
            //BottomObstacle bottom = collision.gameObject.GetComponent<BottomObstacle>();

            playerControl.SetPlayerdeath();
            //bottom.SetTerrainDeath();

            gameOver = GameObject.FindObjectOfType(typeof(GameOverScreen)) as GameOverScreen;
            gameOver.GameOverPart();
        }
    }
}
