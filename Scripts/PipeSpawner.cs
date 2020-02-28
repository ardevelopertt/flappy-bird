using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{

    public GameObject Pipe;
    public float timeSinceLastSpawned;
    public float spawnRate = 3f;
    private Vector2 pipePosition;
    private float pipePositionRandomY;
    const float pipeMin = -0.5f;
    const float pipeMax = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastSpawned = 0f;
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if(timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;
            SpawnPipe();
        }
    }

    void SpawnPipe()
    {
        float randomYPosition = Random.Range(pipeMin, pipeMax);
        pipePosition = new Vector2(transform.localPosition.x, randomYPosition);
        GameObject PipePrefab = Instantiate(Pipe, pipePosition, Quaternion.identity) as GameObject;
        PipePrefab.transform.SetParent(gameObject.transform, false);
        Destroy(PipePrefab, 7);
    }


    public void ResetPipes()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        timeSinceLastSpawned = 3;
    }
}
