using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{

    [SerializeField] public int[] PlayerScales;
    [SerializeField] Text MainText;
    [SerializeField] Text[] TextScales;
    [SerializeField] RawImage[] ImgScales;
    [SerializeField] RawImage[] LivesScales;
    public static GameManager inst;
    public static int scoreGood;
    public static int scoreBad;
    public static long startTime;
    public static long finalScore;
    [SerializeField] public long numOfGetValueMessage;

    private int numOflives;
    private bool IsInjured;


    private void Awake()
    {
        inst = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        numOflives = LivesScales.Length;
        scoreGood = 0;
        scoreBad = 1;
        finalScore = 0;
        startTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        for (int i = 0; i < PlayerScales.Length; i++)
        {
            TextScales[i].text = "" + PlayerScales[i].ToString();
        }
        IsInjured=false;
}

    // Update is called once per frame
    void Update()
    {
        if (win())
        {
            long endTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            startTime = endTime - startTime;
            int pointTime = ((int)Mathf.Max(0, (1000 - startTime)) * 5);
            finalScore = (scoreGood / scoreBad) + pointTime;

            SceneManager.LoadScene("End");
        }
    }

    public Boolean win()
    {
        for (int i = 0; i < PlayerScales.Length; i++)
        {
            if (PlayerScales[i] != 100)
            {
                return false;
            }
        }
        return true;
    }


    public void addScore(Collider other)
    {
        int rand = Random.Range(1, 5);
        
        if (other.tag == "Carbs")
        {
            
            if (PlayerScales[0] >= 100)
            {
                StartCoroutine(waiter(ImgScales[3], false));
                PlayerScales[3]--;
                TextScales[3].text = "" + PlayerScales[3].ToString();
                StartCoroutine(setMainMessage("I'm getting heavy and thirsty"));
            }
            else
            {
                StartCoroutine(waiter(ImgScales[0], true));
                PlayerScales[0]++;
                TextScales[0].text = "" + PlayerScales[0].ToString();
                if (PlayerScales[0] == 100)
                {
                    StartCoroutine(setMainMessage("If i take more Carbs values i will be thirsty"));
                }
                else if((scoreGood/4)+ scoreBad < numOfGetValueMessage)
                {
                    StartCoroutine(setMainMessage("Yes! It's good for Carbs values"));
                }
                
            }
            
        }
        if (other.tag == "Proteins")
        {
            if (PlayerScales[1] >= 100)
            {
                StartCoroutine(waiter(ImgScales[0], false));
                PlayerScales[0]++;
                TextScales[0].text = "" + PlayerScales[0].ToString();
                StartCoroutine(setMainMessage("I'm getting fat"));
            }
            else
            {
                StartCoroutine(waiter(ImgScales[1], true));
                PlayerScales[1]++;
                TextScales[1].text = "" + PlayerScales[1].ToString();
                if (PlayerScales[0] == 100)
                {
                    StartCoroutine(setMainMessage("If i take more Proteins values it will turn into a Carbs"));
                }
                else if ((scoreGood / 4) + scoreBad < numOfGetValueMessage)
                {
                    StartCoroutine(setMainMessage("Yes! It's good for Proteins values"));
                }
            }
            //Destroy(other.gameObject);

        }
        if (other.tag == "VegetablesAndFruits")
        {
            if (PlayerScales[2] >= 100)
            {
                StartCoroutine(waiter(ImgScales[3], false));
                PlayerScales[3]++;
                TextScales[3].text = "" + PlayerScales[3].ToString();
                StartCoroutine(setMainMessage("I'm getting more fresh"));
            }
            else
            {
                StartCoroutine(waiter(ImgScales[2], true));
                PlayerScales[2]++;
                TextScales[2].text = "" + PlayerScales[2].ToString();
                if (PlayerScales[0] == 100)
                {
                    StartCoroutine(setMainMessage("If i take more FruitsAndVeg's values it will turn into a Water values"));
                }
                else if ((scoreGood / 4) + scoreBad < numOfGetValueMessage)
                {
                    StartCoroutine(setMainMessage("Yes! It's good for FruitsAndVeg's values"));
                }
            }


            //Destroy(other.gameObject);
        }
        if (other.tag == "Water")
        {
            if (PlayerScales[3] >= 100)
            {
                StartCoroutine(waiter(ImgScales[0], false));
                StartCoroutine(waiter(ImgScales[1], false));
                StartCoroutine(waiter(ImgScales[2], false));
                PlayerScales[0]--;
                PlayerScales[1]--;
                PlayerScales[2]--;
                TextScales[0].text = "" + PlayerScales[0].ToString();
                TextScales[1].text = "" + PlayerScales[1].ToString();
                TextScales[2].text = "" + PlayerScales[2].ToString();
                StartCoroutine(setMainMessage("Baaa... water poisoning, reduced all the other values"));

            }
            else
            {
                StartCoroutine(waiter(ImgScales[3], true));
                PlayerScales[3]++;
                TextScales[3].text = "" + PlayerScales[3].ToString();
                if (PlayerScales[0] == 100)
                {
                    StartCoroutine(setMainMessage("If i take more Water it will reduce all the other values"));
                }
                else if ((scoreGood / 4) + scoreBad < numOfGetValueMessage)
                {
                    StartCoroutine(setMainMessage("It's refreshing! It's good for Water values"));
                }
            }
            //Destroy(other.gameObject);
            //PlayerScales[5]++;
            //TextScales[5].text = "" + PlayerScales[5].ToString();
        }
        if (other.tag == "PP")
        {
            PlayerScales[0] -= 2;
            PlayerScales[1] -= 2;
            PlayerScales[2] -= 2;
            PlayerScales[3] -= 2;
            TextScales[0].text = "" + PlayerScales[0].ToString();
            TextScales[1].text = "" + PlayerScales[1].ToString();
            TextScales[2].text = "" + PlayerScales[2].ToString();
            TextScales[3].text = "" + PlayerScales[3].ToString();

            StartCoroutine(ToiletPP());
        }

        Boolean negativeNum = (PlayerScales[0] < 0 || PlayerScales[1] < 0 || PlayerScales[2] < 0 || PlayerScales[3] < 0);
        if (negativeNum)
        {
            long endTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            startTime = endTime - startTime;
            finalScore = (scoreGood / (scoreBad*4)) ;

            SceneManager.LoadScene("End");
        }

    }



    IEnumerator waiter(RawImage ImgScales,bool isGood)
    {
        if (isGood)
        {
            scoreGood += 4;
            ImgScales.color = Color.blue;
        }
        else
        {
            scoreBad += 1;
            ImgScales.color = Color.red;
        }

        yield return new WaitForSeconds(0.7f);
        ImgScales.color = Color.white;
    }

    public void setInjured()
    {
        StartCoroutine(addInjured());
    }

    IEnumerator addInjured()
    {

        MainText.text = "Ouch!!!";        
        if (numOflives == 1)
        {
            yield return new WaitForSeconds(0.2f);
            long endTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            startTime = endTime - startTime;
            finalScore = (scoreGood / (scoreBad * 4));

            SceneManager.LoadScene("End");
        }
        else
        {

            numOflives--;
            Destroy(LivesScales[numOflives]);
            IsInjured = true;
            yield return new WaitForSeconds(3.0f);
            IsInjured = false;
            MainText.text = "";
        }


    }

    public bool getInjured()
    {
        return IsInjured;
    }

    IEnumerator ToiletPP()
    {
        
                

        for (int i = 0; i < ImgScales.Length; i++)
        {
            ImgScales[i].color = Color.green;
        }
        //scoreGood += 10;
        MainText.text = "pishhh...(Going into the bathroom)";
        yield return new WaitForSeconds(4.0f);
        MainText.text = "";
        for (int i = 0; i < ImgScales.Length; i++)
        {
            ImgScales[i].color = Color.white;
        }
    }

    IEnumerator setMainMessage(string textMessage)
    {
        MainText.text = textMessage;
        yield return new WaitForSeconds(4.0f);
        MainText.text = "";
    }



}
