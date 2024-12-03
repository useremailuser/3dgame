using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    public float spawnTime = 3f;
    public GameObject Origin;
    public Vector3 spawnPos;

    public GameObject ground;
    void Update()
    {
        Vector3 spawnPos = transform.position;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ground.GetComponent<NavMeshSurface>().enabled = false;
        InvokeRepeating("SpawnEnemy", spawnTime, spawnTime);
        ground.GetComponent<NavMeshSurface>().enabled = true;


    }

    // Update is called once per frame


    public void SpawnEnemy()
    {

       Instantiate(Enemy, spawnPos, Quaternion.identity);
        // GameObject instance = Instantiate(Enemy, spawnPos, Quaternion.identity);
      //  NavMeshAgent.Warp(spawnPos, Enemy);
    }

}
