using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//Code done by Jihad
//It is a code to tell the player's movement, and speed, and the rotation
//The jump function is done by forming a rigidbody to the ground and having the player be able to jump by the rigidbody by pressing the key
public class Controls : MonoBehaviour
{
    public Data data;
    public int playermovement;
    public float movementSpeed = 6.0f;
    public float rotateSpeed = 40f;
    public Rigidbody rb;

    public float JumpHeight = 5;
    private bool jump;
    public bool onGround;

    // Start is called before the first frame update
    void Start()
    {
        data = FindObjectOfType<Data>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("Battle Scene");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            onGround = false;
        }

    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //Vector3 direction = new Vector3(horizontalInput, 0f, 0f);
        transform.Translate(0, 0, verticalInput * movementSpeed * Time.deltaTime);
        transform.Rotate(0, horizontalInput * rotateSpeed * Time.deltaTime, 0);

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.AddForce(new Vector3(0, JumpHeight, 0),ForceMode.Impulse);
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