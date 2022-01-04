using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextManagerHelp : MonoBehaviour
{
    [SerializeField] Text textNum;
    [SerializeField] GameObject[] imgs;
    [SerializeField] String [] strNum;
    [SerializeField] String NextScene;
    private int clickNum;

    // Start is called before the first frame update
    void Start()
    {
        clickNum = 0;
    }

    public void addOne()
    {
        if (clickNum < imgs.Length-1) //event number...
        {
            imgs[clickNum].SetActive(false);
            clickNum++;
            textNum.text = strNum[clickNum];
            imgs[clickNum].SetActive(true);
        }
        else if (clickNum >= imgs.Length-1) //end of the events
        {
            SceneManager.LoadScene(NextScene);
        }

    }
}
