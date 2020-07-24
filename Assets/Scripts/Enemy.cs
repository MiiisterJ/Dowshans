using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyStats Monster;
    [ReadOnly] [SerializeField]
    string Name;
    public TextMesh TextTest;

    public int MonsterID;
    public bool Boss;
    public int Level;

    // Start is called before the first frame update
    void Start()
    {
        Monster = new EnemyStats(MonsterID, Boss, Level);
        Name = Monster.Name;
        TextTest.text = Name + " lvl. " + Monster.Level;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
