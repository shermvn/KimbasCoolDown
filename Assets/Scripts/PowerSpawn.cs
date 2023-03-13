using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpawn : MonoBehaviour
{
    public static PowerSpawn Instance;
    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;
    public GameObject CurrentPowerUp;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject PU = Instantiate(prefab);
        PU.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }

    public void DestroyPowerup()
    {
        Destroy(CurrentPowerUp);
    }
}
