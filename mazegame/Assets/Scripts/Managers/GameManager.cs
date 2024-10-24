using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public int currentKeys;
    public TextMeshProUGUI keyText;

    public int currentGems;
    public TextMeshProUGUI gemText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddKey(int keysToAdd)
    {
        currentKeys += keysToAdd;
        keyText.text = "Keys: " + currentKeys;
    }

    public void TakeKey(int keysToTake)
    {
        currentKeys += keysToTake;
        keyText.text = "Keys: " + currentKeys;
    }

    public void AddGem(int gemsToAdd)
    {
        currentGems += gemsToAdd;
        gemText.text = "Gems: " + currentGems;
    }

}
