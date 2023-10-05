using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontroller : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float cameraSpeed;
    public Camera mainCamera;
    int maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 10;
    }

    // Update is called once per frame
    void Update()
    {
        //Player movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate the forward direction relative to the camera.
        Vector3 forwardDirection = mainCamera.transform.forward;
        forwardDirection.y = 0; // Make sure it's horizontal (ignores vertical rotation).

        // Normalize the direction to maintain consistent speed.
        forwardDirection.Normalize();

        // Calculate the right direction relative to the camera.
        Vector3 rightDirection = mainCamera.transform.right;
        rightDirection.y = 0;
        rightDirection.Normalize();

        // Calculate the desired movement direction based on input.
        Vector3 moveDirection = (forwardDirection * vertical + rightDirection * horizontal).normalized;

        // Move the player.
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        //player rotation
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * cameraSpeed, 0);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            maxHealth -= 5;

            if(maxHealth <= 0)
            {
                gameOver();
            }
        }

        if(collision.gameObject.tag == "plane")
        {
            gameOver();
        }
    }

    public void gameOver()
    {
        SceneManager.LoadScene("Game Over");
    }
}