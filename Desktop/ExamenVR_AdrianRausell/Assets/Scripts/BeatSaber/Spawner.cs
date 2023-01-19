using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject CubeOrange;
    public GameObject CubeBlue;
    public bool stopSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LaunchCube", 2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LaunchCube()
    {
        int random = Random.Range(1,3);
        if (random == 1)
        {
            Instantiate(CubeOrange, transform.position, transform.rotation);
        }
        
        else if (random == 2)
        {
            Instantiate(CubeBlue, transform.position, transform.rotation);
        }

        if(stopSpawning){
            CancelInvoke("LaunchCube");
        }
    }
}
