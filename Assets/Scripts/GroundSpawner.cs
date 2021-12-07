
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject GroundTile;
    Vector3 nextSpawn;


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 15; i++) {
            if (i < 1)
            {
                spawnTile(false); 
            }
            else
            {
                spawnTile(true);
            }
        }

    }


    public void spawnTile(bool flag)
    {

        GameObject temp = Instantiate(GroundTile, nextSpawn, Quaternion.identity);
        nextSpawn = temp.transform.GetChild(1).transform.position;
        if (flag)
        {
            temp.GetComponent<GroundTile>().SpawnObs();
            temp.GetComponent<GroundTile>().SpawnFruit();
        }


    }



}
