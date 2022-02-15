using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject egg;
    public bool eggThere;
    [SerializeField] public float timeToSpawn;
    [SerializeField] public float currentTimeToSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        // SpawnEgg();
    }

    // Update is called once per frame
    void Update()
    { if (!eggThere)
        {if (currentTimeToSpawn > 0)
        {
            currentTimeToSpawn -= Time.deltaTime;
        } else if (currentTimeToSpawn <= 0)
        { 
            SpawnEgg();
            currentTimeToSpawn = timeToSpawn;
        }
        }                   
    }

    void SpawnEgg()
    {
        Instantiate(egg, transform.position, egg.transform.rotation);
        eggThere = true;
    }
}
