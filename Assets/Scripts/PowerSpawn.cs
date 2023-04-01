using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpawn : MonoBehaviour
{
    public static PowerSpawn Instance;
    //    public GameObject prefab;
    //    public float spawnRate = 1f;
    //    public float minHeight = -1f;
    //    public float maxHeight = 1f;
    //    public GameObject CurrentPowerUp;

    //    private void OnEnable()
    //    {
    //        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    //    }

    //    private void OnDisable()
    //    {
    //        CancelInvoke(nameof(Spawn));
    //    }

    //    private void Spawn()
    //    {
    //        GameObject PU = Instantiate(prefab);
    //        PU.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    //    }

    //    public void DestroyPowerup()
    //    {
    //        Destroy(CurrentPowerUp);
    //    }
    //}
    [SerializeField] float spawnRate = 1f;
    [SerializeField] private float minHeight = -5f;
    [SerializeField] private float maxHeight = 5f;
    [SerializeField] GameObject[] PowSpawn;

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
    private void Start()
    {
        StartCoroutine(pSpawn());

    }
    IEnumerator pSpawn()
    {
        while (true)
        {
            var wanted = Random.Range(minHeight, maxHeight);
            var position = new Vector3(12, wanted);
            GameObject PS = Instantiate(PowSpawn[Random.Range(0, PowSpawn.Length)],
            position, Quaternion.identity);
            //PS.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
            yield return new WaitForSeconds(spawnRate);
            Destroy(PS, 5f);


        }
    }
}
