using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

// This class represents the help process, every time you press the "space" key we move on to the next step
public class OnSpaceClick : MonoBehaviour
{


    [SerializeField] TextMeshPro TextPlayer; //Process text mesh
    [SerializeField] string[] TextNum;  //Text num  
    [SerializeField] protected KeyCode SpaceKey; //the key to continue

    [SerializeField] Mover Wrong;
    [SerializeField] Vector3 velocityOfSpawnedObject;
    [SerializeField] Mover Right;

    private bool flag;
    private int numOfClicks;

    // Start is called before the first frame update
    void Start()
    {
        numOfClicks = -1;
        flag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(SpaceKey))//number of press +1
        {
            numOfClicks++;
        }

        if (numOfClicks < TextNum.Length && numOfClicks > -1)
        {
            TextPlayer.SetText(TextNum[numOfClicks]);
        }
        else if(numOfClicks == TextNum.Length)
        {
            TextPlayer.SetText("End of help");
        }
        else if (numOfClicks > TextNum.Length)
        {
            SceneManager.LoadScene("Main"); ;
        }
        if (numOfClicks==4 && flag)
        {
            flag = false;
            this.StartCoroutine(SpawnRoutine());
        }
        if (numOfClicks == 5 && !flag)
        {
            flag = true;
            this.StartCoroutine(SpawnRoutine());
        }

    }

    //spawn when step 4 or 5
    private IEnumerator SpawnRoutine()
    {
        while (numOfClicks==4)
        {
            float timeBetweenSpawns = Random.Range(1, 3);
            yield return new WaitForSeconds(timeBetweenSpawns);
            Vector3 positionOfSpawnedObject = new Vector3(
                -0.5f + Random.Range(-6, +6),
                5.5f,
                transform.position.z);
            GameObject newObject = Instantiate(Wrong.gameObject, positionOfSpawnedObject, Quaternion.identity);
            newObject.GetComponent<Mover>().SetVelocity(velocityOfSpawnedObject);
        }
        while (numOfClicks == 5)
        {
            float timeBetweenSpawns = Random.Range(1, 3);
            yield return new WaitForSeconds(timeBetweenSpawns);
            Vector3 positionOfSpawnedObject = new Vector3(
                -0.5f + Random.Range(-6, +6),
                5.5f,
                transform.position.z);
            GameObject newObject = Instantiate(Right.gameObject, positionOfSpawnedObject, Quaternion.identity);
            newObject.GetComponent<Mover>().SetVelocity(velocityOfSpawnedObject);
        }

    }

}
