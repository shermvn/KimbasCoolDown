using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;
    //public GameObject prefab;
    [SerializeField] float spawnRate = 1f;
    private float minHeight = 12f;
    private float maxHeight = 12f;
    [SerializeField] GameObject[] Spawny;

    //private void OnEnable()
    //{
    //    InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    //}

    //public void OnDisable()
    //{
    //    CancelInvoke(nameof(Spawn));
    //}

    //private void Spawn()
    //{
    //    if (GameBehavior.Instance.CurrentState == State.Play)
    //    {
    //        Instantiate(prefab);
    //    }
    //    else
    //    {
    //        CancelInvoke(nameof(Spawn));
    //    }

    // }

    //public void DestroySpawn()
    //{
    //    Destroy(gameObject);
    //}
    void Start()
    {
        StartCoroutine(Spawn());
        
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            var wanted = Random.Range(minHeight, maxHeight);
            var position = new Vector3(wanted, transform.position.y);
            GameObject OB = Instantiate(Spawny[Random.Range(0, Spawny.Length)],
            position, Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
            Destroy(OB, 5f);


        }
    }
}
