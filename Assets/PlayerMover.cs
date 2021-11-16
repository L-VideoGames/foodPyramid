using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/**
 * This component moves its object when the player clicks the arrow keys.
 */
public class PlayerMover : MonoBehaviour
{
    [Tooltip("Speed of movement, in meters per second")]
    [SerializeField] float speed;
    [SerializeField] SpriteRenderer mySpriteRenderer;
    [SerializeField] TextMeshPro[] TextScales;
    [SerializeField] int[] PlayerScales;

    [SerializeField] GameObject[] Triggers;
    //[SerializeField] GameObject End;
    //[SerializeField] TextMeshPro MainText;
    //private bool Win;
    public Rigidbody2D rb;


    void Start()
    {
        for (int i = 0; i < PlayerScales.Length; i++)
        {
            TextScales[i].text = "" + PlayerScales[i].ToString();
        }
        
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal"); // +1 if right arrow is pushed, -1 if left arrow is pushed, 0 otherwise
        //float y = Input.GetAxis("Vertical");     // +1 if up arrow is pushed, -1 if down arrow is pushed, 0 otherwise


        Vector3 movementVector = new Vector3(x, 0, 0) * speed * Time.deltaTime;
        transform.position += movementVector;

    }



    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.tag == "Sugar")
        {
            Destroy(other.gameObject);
            PlayerScales[0]++;
            TextScales[0].text = "" + PlayerScales[0].ToString();
        }
        if (other.tag == "Proteins")
        {
            Destroy(other.gameObject);
            PlayerScales[1]++;
            TextScales[1].text = "" + PlayerScales[1].ToString();
        }
        if (other.tag == "VegetablesAndFruits")
        {
            Destroy(other.gameObject);
            PlayerScales[2]++;
            TextScales[2].text = "" + PlayerScales[2].ToString();
        }
        if (other.tag == "Fats")
        {
            Destroy(other.gameObject);
            PlayerScales[3]++;
            TextScales[3].text = "" + PlayerScales[3].ToString();
        }
        if (other.tag == "Cereals")
        {
            Destroy(other.gameObject);
            PlayerScales[4]++;
            TextScales[4].text = "" + PlayerScales[4].ToString();
        }
        if (other.tag == "Water")
        {
            Destroy(other.gameObject);
            PlayerScales[5]++;
            TextScales[5].text = "" + PlayerScales[5].ToString();
        }


    }

}

