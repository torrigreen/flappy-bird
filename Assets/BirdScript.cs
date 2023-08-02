using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public LogicScript logic;
    public PipeSpawnScript pipeSpawn;
    public Rigidbody2D myRigidbody;
    public GameObject myWing;
    public float flapStrength;
    public bool hasStarted = false;
    public bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        pipeSpawn = GameObject.FindGameObjectWithTag("Pipe").GetComponent<PipeSpawnScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted && Input.GetKeyDown(KeyCode.Space))
        {
            hasStarted = true;
            pipeSpawn.enabled = true;
            myWing.GetComponent<Animator>().enabled = true;
            myRigidbody.gravityScale = 4.5f;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && isAlive)
        {
            logic.quitGame();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        isAlive = false;
    }
}
