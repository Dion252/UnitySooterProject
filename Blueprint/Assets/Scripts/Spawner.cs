using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{

    public float time;

    public GameObject enemyType;

    private float nextWaveTime;


    // Start is called before the first frame update
    void Start()
    {

        nextWaveTime = Random.Range(0, time);

    }

    // Update is called once per frame
    void Update()
    {

        nextWaveTime -= Time.deltaTime;

        if (nextWaveTime <= 0.0f)
        {
            nextWaveTime = time;

            Instantiate(enemyType, transform.position, transform.rotation);
        }

    }
}
