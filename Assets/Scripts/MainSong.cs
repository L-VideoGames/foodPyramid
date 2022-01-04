using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSong : MonoBehaviour
{
    // Start is called before the first frame update
void Awake()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Song");
        if (obj.Length > 1)
        {

            
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        


    }
}
