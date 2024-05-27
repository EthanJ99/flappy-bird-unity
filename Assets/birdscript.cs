using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdscript : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float flapStrength;
    public LogicScript logic;

    // private float rotationSpeedAscend = 100.0f;
    // private float rotationSpeedDescend = 200.0f;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Space) == true && logic.gameIsPlaying())
        {
            rigidBody.velocity = Vector2.up * flapStrength;
        }
    }

    private void FixedUpdate()
    {
        // Rotate bird based on its ascent/descent
        transform.rotation = Quaternion.Euler(0, 0, rigidBody.velocity.y * rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Game over if bird collides with pipe
        logic.gameOver();
    }

    private void OnBecameInvisible()
    {
        // Game over if bird falls off screen
        // NOTE - Unity prints a warning if bird dies from hitting a pipe (since the bird object is deleted after the fall, but then
        // when the sprite turns invisible it tries to delete it again here)
        logic.gameOver();
    }

    private bool isAscending()
    {
        return rigidBody.velocity.y > 0;
    }

}
