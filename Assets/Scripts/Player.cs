using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    private Rigidbody rb;
    public float upForce = 10f;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * upForce,ForceMode.Impulse);
        }

        // lose when player falls screen
        if(transform.position.y < -5)
        {
            SceneManager.LoadScene("GameLose");
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        // lose when player collides with obstacle
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene("GameLose");
        }
    }
}
