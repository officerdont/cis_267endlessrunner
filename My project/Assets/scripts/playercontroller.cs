using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontroller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D PlayerRigidbody2D;
    public GameObject PlatformPrefab;
    public float Movementspeed;
    public float Jumpforce;
    private float inputhorizontal;   
    private bool isgrounded = false;
    // i put is grounded back so the player dosent get an extra jump if they walk off the edge
   // private int maxjumps;
    private int numofjumps;
    private int doublejumps;
    private bool doublejumpused = false;
    private int hammer;
    private bool shield = false;

    void Start()
    {
        PlayerRigidbody2D = GetComponent<Rigidbody2D>();
      //  maxjumps = 1; 
        numofjumps = 0;
        doublejumps = 0;
        hammer = 0;

    }

    // Update is called once per frame
    void Update()
    {
        moveplayerlateral();
        jump();
        platformcreator();
    }

    private void moveplayerlateral()
    {
        inputhorizontal = Input.GetAxisRaw("Horizontal");
        PlayerRigidbody2D.linearVelocity = new Vector2(inputhorizontal * Movementspeed, PlayerRigidbody2D.linearVelocity.y);



    }

    private void jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
            PlayerRigidbody2D.linearVelocity = new Vector2(PlayerRigidbody2D.linearVelocity.x, Jumpforce);
            numofjumps++;
        }

        else if(Input.GetKeyDown(KeyCode.Space) && doublejumps > 0 && doublejumpused == false)
        {
            doublejumps = doublejumps - 1;
            Scoremanager.instance.AddBoots(-1);
            doublejumpused = true;
            PlayerRigidbody2D.linearVelocity = new Vector2(PlayerRigidbody2D.linearVelocity.x, Jumpforce);
            numofjumps++;
        }

    }

    private void platformcreator()
    {

        if (Input.GetKeyDown(KeyCode.Q) && hammer > 0)
        {
            // spawn platform beneth the player
            Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y - 1.5f);
            Instantiate(PlatformPrefab, spawnPosition, Quaternion.identity);
            hammer--; 
            Scoremanager.instance.AddHammer(-1);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("grounded"))
        {
            isgrounded = true;
            doublejumpused = false;
            numofjumps = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("grounded"))
        {
            isgrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("doublejump"))
        {
            if(doublejumps < 3 )
            {
                doublejumps++;
                Scoremanager.instance.AddBoots(1);
            }

            Scoremanager.instance.AddScore(10);
            Destroy(collision.gameObject);
            
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("hammer"))
        {
           
            if(hammer < 2 )
            {
                hammer++;
                Scoremanager.instance.AddHammer(1);

            }
            Scoremanager.instance.AddScore(20);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("shield"))
        {
            if (!shield)
            {
                Scoremanager.instance.AddShield(1);
            }
            shield = true;
            
            Scoremanager.instance.AddScore(30);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("obstacle"))
        {
            if(shield)
            {
                shield = false;
                Scoremanager.instance.AddShield(-1);
                Debug.Log("Shield absorbed the hit!");
                Destroy(collision.gameObject);
                // buffer the player from damage

            }
            else
            {
                Debug.Log("Player hit by obstacle without shield!");
                Scoremanager.instance.changescores();
                SceneManager.LoadScene(0);
                Destroy(gameObject);
                // Handle player death or damage here
            }
           
        }
        {
            
        }
    }



   

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bottomborder"))
        {
            
            
            Debug.Log("Player has fallen off the bottom of the screen.");
            Scoremanager.instance.changescores();
            SceneManager.LoadScene(0);


        }
    }
   

}
