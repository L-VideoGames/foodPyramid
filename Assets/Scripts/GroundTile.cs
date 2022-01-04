
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawn;
    [SerializeField] GameObject ObsPrefab;
    [SerializeField] GameObject[] FruitPrefab;
    [SerializeField] GameObject PortaPotty;
    
    [SerializeField] int numOfFood = 2;

    // Start is called before the first frame update
    void Start()
    {
        groundSpawn = GameObject.FindObjectOfType<GroundSpawner>();
        //SpawnObs();
        //SpawnFruit();
    }


    private void OnTriggerExit(Collider other)
    {
        groundSpawn.spawnTile(true);
        //groundSpawn.spa
        Destroy(gameObject, 2);
    }

    public void SpawnObs()
    {
        //choose a random position
        int rand = Random.Range(2, 5);
        Transform SpawnPoint = transform.GetChild(rand).transform;
        //Spawn the object
        Instantiate(ObsPrefab, SpawnPoint.position, Quaternion.identity, transform);


    }

    public void SpawnFruit()
    {
        for(int i = 0; i< FruitPrefab.Length; i++)
        {
            for (int j = 0; j < numOfFood; j++)
            {
                GameObject temp = Instantiate(FruitPrefab[i], transform);
                temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
            }
            //GameObject temp = Instantiate(FruitPrefab, transform);
            //temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }


    }

    public void SpawnPP()
    {
        //choose a random position
        int rand = Random.Range(2, 5);
        Transform SpawnPoint = transform.GetChild(rand).transform;
        //Spawn the object
        Instantiate(PortaPotty, SpawnPoint.position, Quaternion.identity, transform);


    }
    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            (int)Random.Range(collider.bounds.min.x+1f, collider.bounds.max.x-1f),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }





    // Update is called once per frame
    void Update()
    {
        
    }
}
