using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public int remainingHealth;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public CharacterController thePlayer;
    public Animator fadeOut;

    // Start is called before the first frame update
    void Start()
    {
        remainingHealth = numOfHearts;
        thePlayer = FindObjectOfType<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (remainingHealth > numOfHearts) 
        {
            remainingHealth = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++) 
        {
            if(i < remainingHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            
            
            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void HurtPlayer(int damage)
    {
        remainingHealth -= damage;

        if(remainingHealth <= 0)
        {
            fadeOut.Play("Death Fade");
        }
    
    }

    public void HealPlayer(int healAmount)
    {
        remainingHealth += healAmount;

        if(remainingHealth > numOfHearts)
        {
            remainingHealth = numOfHearts;
        }
    }
}
