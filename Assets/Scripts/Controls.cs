using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code done by Jihad
//It is a code to tell the player's movement, and speed, and the rotation
//The jump function is done by forming a rigidbody to the ground and having the player be able to jump by the rigidbody by pressing the key
public class Controls : MonoBehaviour
{
    public float jumpSpeed = 6.0f;
    public int playermovement;
    public bool playerhit;
    public float movementSpeed = 6.0f;
    public float rotateSpeed = 40f;
    public Rigidbody rb;

    public float jump_timer;
    private bool jump;
    public bool onGround;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }
    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //Vector3 direction = new Vector3(horizontalInput, 0f, 0f);
        transform.Translate(0, 0, verticalInput * movementSpeed * Time.deltaTime);
        transform.Rotate(0, horizontalInput * rotateSpeed * Time.deltaTime, 0);

        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y <= 3.8f)
        {
            rb.AddForce(new Vector3(0, 7, 0),ForceMode.Impulse);
        }
        //if (Input.GetKeyDown(KeyCode.Space) && !jump && onGround)
        //{
        //    jump_timer = 0.6f;
        //    jump = true;
        //}

        //if (jump && jump_timer > 0)
        //{
        //    jump_timer -= Time.deltaTime;
        //    transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * jumpSpeed, transform.position.z);
        //    if (jump_timer <= 0)
        //    {
        //        jump = true;
        //    }
        //}
    }
}