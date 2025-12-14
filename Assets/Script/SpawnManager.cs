using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float heightRange = 2f;
    [SerializeField] private float spawnRate = 2f;

    private void Start()
    {
        StartCoroutine(SpawnPipeRoutine());
    }

    IEnumerator SpawnPipeRoutine()
    {

        while (GameManager.Instance.IsGameStarted())
        {
            yield return null;
        }

        while (true)
        {
            //Debug.Log("Spawn!");
            //SpawnPipe();
            if (GameManager.Instance.IsGameStarted() && !GameManager.Instance.IsGameOver()) SpawnPipe();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    void SpawnPipe()
    {
        if (pipePrefab == null) Debug.LogError ("Prefab nott assigned in the SpawnManager!");

        float randomY = Random.Range(-heightRange, heightRange);
        Vector2 spawnPosition = new Vector2(10f, randomY);
        Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
    }
}
