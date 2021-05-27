using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustSpawner : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject prefabDust;
    public void SpawnDust()
    {
        Instantiate(prefabDust, spawnPoint.position, spawnPoint.rotation);
    }

    public void RespirarFuerte()
    {
        print("Respira fuerte");
    }
}
