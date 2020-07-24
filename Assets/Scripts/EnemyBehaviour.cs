using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Code by Jihad (Further modifications by Max S.)
// This is a script which puts the player from one scene to the other by colliding, 
// It is done so that the enemy/boss will initiate the scene when they touch they player
public class EnemyBehaviour : MonoBehaviour
{
    public int scene;
    public Enemy EnemyType;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(scene);
        }
    }

}
