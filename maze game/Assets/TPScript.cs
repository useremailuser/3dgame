using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.Rendering.DebugUI;

public class TPScript : MonoBehaviour
{
    public GameObject player;
    public GameObject tp1;
    public Transform tp2;
    public GameObject ground;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("heloo");
            ground.GetComponent<NavMeshSurface>().enabled = false; 
            
            player.transform.position = tp2.position;
            
            ground.GetComponent<NavMeshSurface>().enabled = true;
                
        }
    }

}
