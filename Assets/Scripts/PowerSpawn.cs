using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpawn : MonoBehaviour
{
    public static PowerSpawn Instance;

    [SerializeField] float spawnRate = 1f;
    [SerializeField] private float minHeight = -5f;
    [SerializeField] private float maxHeight = 5f;
    [SerializeField] GameObject[] PowSpawn;

 
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
