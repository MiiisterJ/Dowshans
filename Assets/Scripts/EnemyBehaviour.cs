using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Code by Jihad (Further modifications by Max S.)
// This is a script which puts the player from one scene to the other by colliding with the enemy, 
// It is done so that the enemy/boss will initiate the scene when they touch they player in the world map
public class EnemyBehaviour : MonoBehaviour
{
    public GameObject player;
    Scene currentScene;
    Rigidbody rb;

    string enterScene = "Battle Scene";
    public EnemyStats EnemyType;

    float player_x;
    float player_z;

    float monster_x;
    float monster_z;

    bool followPlayer;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Character");
    }

    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Rocky Mountains" || currentScene.name == "Dark Castle")
            FollowPlayer();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DontDestroyOnLoad(EnemyType);
            SceneManager.LoadScene(enterScene);
            transform.position = new Vector3(-16, 2, -6);
            try
            {
                rb.constraints = RigidbodyConstraints.FreezeAll;
            }
            catch { }

        }
    }

    void FollowPlayer()
    {
        player_x = player.transform.position.x;
        player_z = player.transform.position.z;

        monster_x = transform.position.x;
        monster_z = transform.position.z;

        if (monster_x > player_x)
        {
            monster_x -= Time.deltaTime * moveSpeed;
        }
        if (monster_x < player_x)
        {
            monster_x += Time.deltaTime * moveSpeed;
        }
        if (monster_z > player_z)
        {
            monster_z -= Time.deltaTime * moveSpeed;
        }
        if (monster_z < player_z)
        {
            monster_z += Time.deltaTime * moveSpeed;
        }

        if (followPlayer)
        {
            transform.position = new Vector3(monster_x, transform.position.y, monster_z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            followPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            followPlayer = false;
        }
    }

}
