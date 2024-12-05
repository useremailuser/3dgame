using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    int x = 10;
    int y = 300;
    public float speed;
    public int score;
    int totalCoins; 

    public Text scoreText;
    public Text timerText;
    float timer;




    // Start is called before the first frame update
    void Start()
    {
        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        Debug.Log(x + y);
        speed = 500;
        scoreText.text = "0/" + totalCoins;
        timer = 0;

    }

    // Update is called once per frame
    void Update()

    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
        
            if (transform.position.y < -40)
            { 
            SceneManager.LoadScene(0);
        }



        if (score < totalCoins)
        {
            timer += Time.deltaTime;
        }
        timerText.text = (Mathf.Round(timer * 100) / 100).ToString();

        //if (Input.GetKeyDown(KeyCode.LeftShift))

        //{
        //    speed = 1000;
        //}


        //if (Input.GetKeyUp(KeyCode.LeftShift))

        //{
        //    speed = 500;
        //}


        //if (Input.GetKey(KeyCode.W))

        //{
        //    GetComponent<Rigidbody>().AddForce(0, 0, 1 * speed * Time.deltaTime);
        //}

        //if (Input.GetKey(KeyCode.S))

        //{
        //    GetComponent<Rigidbody>().AddForce(0, 0, -1 * speed * Time.deltaTime);

        //}
        //{
        //    if (Input.GetKey(KeyCode.A))

        //    {
        //        GetComponent<Rigidbody>().AddForce(-1 * speed * Time.deltaTime, 0, 0);
        //    }
        //}

        //{
        //    if (Input.GetKey(KeyCode.D))

        //    {
        //        GetComponent<Rigidbody>().AddForce(1 * speed * Time.deltaTime, 0, 0);
        //    }
        //}
    }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("coin get");
            score += 1;
            scoreText.text = score + "/" + totalCoins;
            Destroy(other.gameObject);

        }
    
}


    /*
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))

        {
            speed = 10;
        }


        if (Input.GetKeyUp(KeyCode.LeftShift))

        {
            speed = 4;
        }


        if (Input.GetKey(KeyCode.W))

        {
            transform.Translate(0, 0, 1 * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.S))

        {
            transform.Translate(0, 0, -1 * Time.deltaTime * speed);

        }
        {
            if (Input.GetKey(KeyCode.A))

            {
                transform.Translate(-1 * Time.deltaTime * speed, 0, 0);
            }
        }

        {
            if (Input.GetKey(KeyCode.D))

            {
                transform.Translate(1 * Time.deltaTime * speed, 0, 0);
            }

        }
    }
    */


