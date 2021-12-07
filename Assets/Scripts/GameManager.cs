using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{

    [SerializeField] protected int[] PlayerScales;
    [SerializeField] Text[] TextScales;
    
    public static GameManager inst;

    private void Awake()
    {
        inst = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < PlayerScales.Length; i++)
        {
            TextScales[i].text = "" + PlayerScales[i].ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    public void addScore(Collider other)
    {
        int rand = Random.Range(1, 5);

        if (other.tag == "Sugar")
        {
            if (PlayerScales[0] == 100)
            {
                PlayerScales[5]--;
                TextScales[5].text = "" + PlayerScales[5].ToString();
            }
            else
            {
                PlayerScales[0]++;
                TextScales[0].text = "" + PlayerScales[0].ToString();
            }

            //Destroy(other.gameObject);
            //PlayerScales[0]++;
            //TextScales[0].text = "" + PlayerScales[0].ToString();
        }
        if (other.tag == "Proteins")
        {
            if (PlayerScales[1] == 100)
            {
                PlayerScales[rand]--;
                TextScales[rand].text = "" + PlayerScales[rand].ToString();
            }
            else
            {
                PlayerScales[1]++;
                TextScales[1].text = "" + PlayerScales[1].ToString();
            }
            //Destroy(other.gameObject);

        }
        if (other.tag == "VegetablesAndFruits")
        {
            if (PlayerScales[2] == 100)
            {
                PlayerScales[rand]--;
                TextScales[rand].text = "" + PlayerScales[rand].ToString();
            }
            else
            {
                PlayerScales[2]++;
                TextScales[2].text = "" + PlayerScales[2].ToString();
            }


            //Destroy(other.gameObject);
        }
        if (other.tag == "Fats")
        {
            if (PlayerScales[3] == 100)
            {
                PlayerScales[rand]--;
                TextScales[rand].text = "" + PlayerScales[rand].ToString();
            }
            else
            {
                PlayerScales[3]++;
                TextScales[3].text = "" + PlayerScales[3].ToString();
            }

            //Destroy(other.gameObject);

        }
        if (other.tag == "Cereals")
        {
            if (PlayerScales[4] == 100)
            {
                PlayerScales[rand]--;
                TextScales[rand].text = "" + PlayerScales[rand].ToString();
            }
            else
            {
                PlayerScales[4]++;
                TextScales[4].text = "" + PlayerScales[4].ToString();
            }
            //Destroy(other.gameObject);

        }
        if (other.tag == "Water")
        {
            if (PlayerScales[5] == 100)
            {
                PlayerScales[0]--;
                TextScales[0].text = "" + PlayerScales[0].ToString();
            }
            else
            {
                PlayerScales[5]++;
                TextScales[5].text = "" + PlayerScales[5].ToString();
            }
            //Destroy(other.gameObject);
            //PlayerScales[5]++;
            //TextScales[5].text = "" + PlayerScales[5].ToString();
        }


    }

}
