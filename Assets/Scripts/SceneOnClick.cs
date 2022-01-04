using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOnClick : MonoBehaviour
{

    
    public void SceneName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        // Destroy the gameObject after clicking on it
        if (this.tag == "Levels")
        {
            Destroy(GameObject.FindGameObjectWithTag("Song"));
        }
        

    }
}