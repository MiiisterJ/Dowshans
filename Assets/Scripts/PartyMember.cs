using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/// <summary>
/// Coded by Max Seward (1TheBlueWii1)
/// </summary>
public class PartyMember : MonoBehaviour
{
#if DEBUG
    [ReadOnly] [SerializeField]
#endif
    string _name;
    public string Name { get { return _name; } private set { _name = value; } }

    public int MemberID;

    public bool InParty;
    
    double HPMultiplier; //Used when a character levels up.
    int baseHP;
#if DEBUG
    [ReadOnly] [SerializeField]
#endif
    int _maxHP;
    public int maxHP { get { return _maxHP; } private set { _maxHP = value; } }
    public int HP;

    double ManaMultiplier; //Used when a character levels up.
    int baseMana;
#if DEBUG
    [ReadOnly] [SerializeField]
#endif
    int _maxMana;
    public int maxMana { get { return _maxMana; } private set { _maxMana = value; } }
    public int Mana;

#if DEBUG
    [ReadOnly] [SerializeField]
#endif
    int _level;
    public int Level { get { return _level; } private set { if (value <= 0) _level = 1; else _level = value; } }
    public int Exp;
#if DEBUG
    [ReadOnly] [SerializeField]
#endif
    int _nextExp;
    public int NextExp() { _nextExp = BASE_MAX_EXP * (Level * Level); return _nextExp; }
    const int BASE_MAX_EXP = 100;
    const int MAX_LEVEL = 100;

    double AtkMultiplier; //Used when a character levels up.
    int baseAtk;
#if DEBUG
    [ReadOnly] [SerializeField]
#endif
    int _attackPower;
    public int Stat_Attack{ get { return _attackPower; } private set { _attackPower = value; } }

    public bool UpdateCharacterStats;


    public PartyMember(int _memberID, int _exp)
    {
        MemberID = _memberID;
        Exp = _exp;

        //Set maximum stats.
        UpdateStats();

        HP = maxHP;
        Mana = maxMana;
    }

    public void Start()
    {
        UpdateStats();

        HP = maxHP;
        Mana = maxMana;
    }

    public void Update()
    {
        if (UpdateCharacterStats)
        {
            UpdateStats();
            UpdateCharacterStats = false;
        }
    }

    /// <summary>
    /// In case a character levels up, run this to update the character's maximum HP and Mana.
    /// </summary>
    public void UpdateStats()
    {
        Character(MemberID);

        int prevLevel = Level;

        for (int lv = 0; lv <= MAX_LEVEL; lv++)
        {
            if (Exp >= NextExp())
            {
                Level = lv;
            }
        }
        if (Level <= 0)
            Level = 1;
        maxHP = Convert.ToInt32(baseHP * (Level * HPMultiplier));
        maxMana = Convert.ToInt32(baseMana * (Level * ManaMultiplier));

        Stat_Attack = Convert.ToInt32(baseAtk * (Level * AtkMultiplier));

        if (prevLevel < Level) //If the character levels up, health and mana is reset.
        {
            HP = maxHP;
            Mana = maxMana;
        }

        if (HP > maxHP)
            HP = maxHP;
        if (Mana > maxMana)
            Mana = maxMana;

        NextExp();
    }

    /// <summary>
    /// Profile of party members you have.
    /// </summary>
    /// <param name="_IDnum">Profile ID number.</param>
    private void Character(int _IDnum)
    {
        switch (_IDnum)
        {
            case 1:
                Name = "Rocky";
                baseHP = 100;
                baseMana = 100;
                baseAtk = 10;

                HPMultiplier = 0.2;
                ManaMultiplier = 0.3;
                AtkMultiplier = 1.5;
                break;
            case 2:
                Name = "Luke";
                baseHP = 100;
                baseMana = 100;
                baseAtk = 10;

                HPMultiplier = 0.25;
                ManaMultiplier = 0.2;
                AtkMultiplier = 1.25;
                break;
            case 3:
                Name = "Jane";
                baseHP = 50;
                baseMana = 60;
                baseAtk = 15;

                HPMultiplier = 0.1;
                ManaMultiplier = 0.6;
                AtkMultiplier = 1.2;
                break;
            case 4:
                Name = "Phoenix";
                baseHP = 130;
                baseMana = 50;
                baseAtk = 5;

                HPMultiplier = 0.08;
                ManaMultiplier = 0.5;
                AtkMultiplier = 2.0;
                break;
        }
    }

}


