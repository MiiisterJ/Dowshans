using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   
    public GameObject player;

    private float player_x;
    private float player_z;

    private float monster_x;
    private float monster_z;


    public string enemyName;
    public int level;
    public int statScale;

    public int maxHP;
    public int HP;
    public int maxDamage;
    public int minDamage;
    public int damage;
    public bool followPlayer;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.Find("Character");
        maxHP = 20 * level;
        HP = maxHP;

        if (level == 0)
        {
            level = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateEnemyStats();
        FollowPlayer();
    }


    void CalculateEnemyStats()
    {
        maxHP = 20 * level;
        minDamage = 3 * level / 2 * statScale / 3;
        maxDamage = 4 * level / 2 * statScale / 3;
        damage = Random.Range(minDamage, maxDamage);
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

