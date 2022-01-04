using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreScene : MonoBehaviour
{
    [SerializeField] Text[] TextScales;

    // Start is called before the first frame update
    void Start()
    {

        TextScales[0].text = "Time: "+GameManager.startTime.ToString()+" sec";
        TextScales[1].text = "Correct: " + (GameManager.scoreGood/4).ToString();
        TextScales[2].text = "Wrong: " + GameManager.scoreBad.ToString();
        StartCoroutine(waiter());

    }

    IEnumerator waiter()
    {
        //int pointTime = ((int)Mathf.Max(0, (1000 - GameManager.startTime)) * 5);
        //long finalScore = (GameManager.scoreGood / GameManager.scoreBad) + pointTime;
        for (int i = 0; i <= GameManager.finalScore; i += 10)
        {
            TextScales[3].text = "Score: " + i.ToString() + " points";
            yield return new WaitForSeconds(0.001f);
        }
        TextScales[3].text = "Score: " + GameManager.finalScore.ToString() + " points";


    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
