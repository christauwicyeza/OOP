using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject fallingObjectPrefab;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        StartCoroutine(SpawnObjectsRoutine());
    }

    private IEnumerator SpawnObjectsRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f); // Adjust spawn interval as needed
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        GameObject newObject = FallingObjectFactory.CreateFallingObject(fallingObjectPrefab, spawnPosition);
        newObject.GetComponent<FallingObject>().Fall();
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float spawnX = Random.Range(-5f, 5f); // Example range, adjust as needed
        float spawnY = 10f; // Spawn objects from top of screen
        return new Vector3(spawnX, spawnY, 0f);
    }
}
