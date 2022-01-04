using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputOnClick : MonoBehaviour
{
    [SerializeField] Text MainText;
    [SerializeField] Text TextInputH;
    [SerializeField] Text TextInputW;
    [SerializeField] Text startAfterText;
    [SerializeField] GameObject[] levelsByCal;
    private bool flag = false;
    private string sceneStr;
    // Start is called before the first frame update


    void Start()
    {
        flag = false;
        sceneStr = "Main";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addInput()
    {
        if (flag)
        {
            SceneManager.LoadScene(sceneStr);
        }

        bool isNumeric1 = float.TryParse(TextInputH.text, out float n);
        //Debug.Log(isNumeric);
        bool isNumeric2 = float.TryParse(TextInputW.text, out n);
        if (isNumeric1 && isNumeric2)
        {
            float h = float.Parse(TextInputH.text);
            if (h > 3f)
            {
                h /= 100;
            }
            float w = float.Parse(TextInputW.text);
            float cal = w / (h * h);
            //Debug.Log(cal);
            levelsByCal[0].SetActive(false);
            startAfterText.text = "The game will start after 5 sec";
            if (cal < 18.5f)
            {
                MainText.text = "You ranked as underweight! You need to gain weight, please eat more proteins but dont forget fruits, vegetables and water!";
                flag = true;
                sceneStr = "underweightLevel";
                StartCoroutine(setScene(sceneStr));

            }
            else if(cal>18.5f && cal < 25f)
            {
                MainText.text = MainText.text = "You rated as a normal weight! Excellent Continue like this! Continue to balance between all nutritional values";
                flag = true;
                sceneStr = "normalLevel";
                StartCoroutine(setScene(sceneStr));
            }
            else
            {
                MainText.text = MainText.text = "You rated as overweight! You need to maintain a healthier diet! Eat more fruits, vegetables, water and significantly less carbs";
                flag = true;
                sceneStr = "overweightLevel";
                StartCoroutine(setScene(sceneStr));
            }
        }
        else
        {
            MainText.text = "Wrong values!!!!! Please enter correct values.";
            //Debug.Log("Wrong var!!!!!");
        }
        /*        for(int i=0;i< TextInput.Length; i++)
                {
                    string str = TextInput[i].text;
                    aaa = int.TryParse(str, )
                }*/
        //return true;
    }


    private IEnumerator setScene(string loadSceneName)
    {
        startAfterText.text = "The game will start after 7 sec";
        yield return new WaitForSeconds(1.0f);
        startAfterText.text = "The game will start after 6 sec";
        yield return new WaitForSeconds(1.0f);
        startAfterText.text = "The game will start after 5 sec";
        yield return new WaitForSeconds(1.0f);
        startAfterText.text = "The game will start after 4 sec";
        yield return new WaitForSeconds(1.0f);
        startAfterText.text = "The game will start after 3 sec";
        yield return new WaitForSeconds(1.0f);
        startAfterText.text = "The game will start after 2 sec";
        yield return new WaitForSeconds(1.0f);
        startAfterText.text = "The game will start after 1 sec";
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(loadSceneName);
    }

}
