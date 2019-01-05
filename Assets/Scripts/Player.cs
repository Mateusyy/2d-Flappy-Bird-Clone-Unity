using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {


    private Rigidbody2D rb;
    public float speed = 1f;
    public static float globalGravity = -9.8f;
    public float gravityScale = 1.0f;
    private bool isForce = false;

    public float heightJump = 5f;

    private void Start() {

        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;

        rb.simulated = false;
    }

    private void FixedUpdate() {
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        rb.AddForce(gravity, ForceMode2D.Force);
    }

    private void Force() {
        isForce = false;
        rb.AddForce(Vector3.up * speed, ForceMode2D.Impulse);
        rb.velocity = new Vector3(0f, heightJump, 0f);
    }

    private void Update() {
        //start
        if(Input.GetMouseButtonDown(0) && FindObjectOfType<GameManager>().isGame == false) {
            FindObjectOfType<GameManager>().StartGame();
            rb.simulated = true;
        }

        //w grze
        if (Input.GetMouseButtonDown(0) && FindObjectOfType<GameManager>().isGame) {
            isForce = true;
        }

        //restart
        if (Input.GetMouseButtonDown(0) && FindObjectOfType<GameManager>().waitForRestart) {
            Application.LoadLevel(Application.loadedLevel);
        }

        if (isForce == true)
            Force();

    }

    private void OnTriggerEnter2D(Collider2D collider) {

        //do zmiany
        gameObject.GetComponent<SpriteRenderer>().sprite = null;
        gameObject.GetComponent<TrailRenderer>().enabled = false;

        FindObjectOfType<GameManager>().EndGame();
    }
}

