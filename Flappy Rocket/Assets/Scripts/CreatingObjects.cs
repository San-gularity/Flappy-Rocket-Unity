using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CreatingObjects : MonoBehaviour
{
    public GameObject bottomTriangle;
    public GameObject topTriangle;
    //public GameObject pointCheck;
    public GameObject CheckBar;


    [SerializeField] private float bottomX = 36.7f;
    [SerializeField] private float topX = 36.7f;
    [SerializeField] private float bottomY;
    [SerializeField] private float topY;


    [SerializeField] private int points = 0;
    [SerializeField] private TextMeshProUGUI pointsText;


    //private float barY;

    //Random rand = new Random();


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            bottomY = Random.Range(-14.0f, -7.0f);
            topY = bottomY + 20.74f;
            Quaternion rot = Quaternion.Euler(0, 0, 90);
            Instantiate(bottomTriangle, new Vector3(bottomX, bottomY, 0), rot);
            Instantiate(topTriangle, new Vector3(topX, topY, 0), rot);
            Instantiate(CheckBar, new Vector3(bottomX, bottomY - 12f, 0), rot);

            points += 1;
            pointsText.text = points.ToString();
            //Instantiate(pointCheck, new Vector3(topX, bottomY + averageY, 0), Quaternion.identity);
            //yield return new WaitForSeconds(0.5f);
        }
    }
    public float GetHighscore()
    {
        return points;
    }
}
