using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Play;

    public GameObject Player;

    public GameObject BlueKey;
    public GameObject BlueDoor;


    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        Debug.Log("ummm");

        if (other.gameObject == Player)
        {
            Debug.Log("uhhh");
            // Destroy(Play);
            // Destroy(Enemy);
            Destroy(BlueDoor);
            Destroy(BlueKey);



        }
    }

}
