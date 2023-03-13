using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;
    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    public void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        if (GameBehavior.Instance.CurrentState == State.Play)
        {
            Instantiate(prefab);
        }
        else
        {
            CancelInvoke(nameof(Spawn));
        }
        //Treat.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
     }

    public void DestroySpawn()
    {
        Destroy(gameObject);
    }
}
