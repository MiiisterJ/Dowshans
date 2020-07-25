using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyStats Monster;
    [ReadOnly] [SerializeField]
    string Name;

    public int MonsterID;
    public bool Boss;
    public int Level;
    public int EnemyAmount;

    // Start is called before the first frame update
    void Start()
    {
        Monster = new EnemyStats(MonsterID, Boss, Level);
        Name = Monster.Name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
