using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class EventOnInput : MonoBehaviour
{
    [SerializeField] private KeyCode triggerKey;
    [SerializeField] private UnityEvent onTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(triggerKey))
        {
            onTrigger.Invoke();
        }
    }
}
