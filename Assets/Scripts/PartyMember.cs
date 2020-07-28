using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyMember : MonoBehaviour
{
    public Data data;
    public int memberID;
    public string memberName;
    public int level;
    public int statScale;

    public int maxHP;
    public int HP;
    public int maxDamage;
    public int minDamage;
    public int damage;
    public int exp;
    public int maxEXP;


    // Start is called before the first frame update
    void Start()
    {
        data = FindObjectOfType<Data>();
        if(level == 0)
        {
            level = 1;
        }
        if(memberID == 0)
        {
            memberName = data.memberName1;
            level = data.level1;
            statScale = data.statScale1;
            maxHP = data.maxHP1;
            HP = data.HP1;
            exp = data.exp1;
            maxEXP = data.maxEXP1;

        }
        if (memberID == 1)
        {
            memberName = data.memberName2;
            level = data.level2;
            statScale = data.statScale2;
            maxHP = data.maxHP2;
            HP = data.HP2;
            exp = data.exp2;
            maxEXP = data.maxEXP2;

        }
        if (memberID == 2)
        {
            memberName = data.memberName3;
            level = data.level3;
            statScale = data.statScale3;
            maxHP = data.maxHP3;
            HP = data.HP3;
            exp = data.exp3;
            maxEXP = data.maxEXP3;

        }
        if (memberID == 3)
        {
            memberName = data.memberName4;
            level = data.level4;
            statScale = data.statScale4;
            maxHP = data.maxHP4;
            HP = data.HP4;
            exp = data.exp4;
            maxEXP = data.maxEXP4;

        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateStats();
    }

    void CalculateStats()
    {
        minDamage = level * statScale / 3;
        maxDamage = level * 2 * statScale / 3;
        damage = Random.Range(minDamage, maxDamage);
        maxEXP = 100 * level / 5;
        if(HP > maxHP)
        {
            HP = maxHP;
        }
        if( exp > maxEXP)
        {
            exp = 0;
            level++;
        }
    }
}
