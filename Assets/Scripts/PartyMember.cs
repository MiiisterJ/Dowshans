using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/// <summary>
/// Do NOT apply this to a game object. This is called by the GameLogic script.
/// 
/// Coded by Max Seward (1TheBlueWii1)
/// </summary>
public class PartyMember : MonoBehaviour
{
    string charName;
    public string Name { get; private set; }

    
    double HPMultiplier; //Used when a character levels up.
    int baseHP;
    public int maxHP { get; private set; }
    public int HP;

    double ManaMultiplier; //Used when a character levels up.
    int baseMana;
    public int maxMana { get; private set; }
    public int Mana;

    public int Level { get; private set; }
    public int Exp;
    public int NextExp { get { return baseMaxExp * (Level * Level); } }
    int baseMaxExp = 100;
    const int MAX_LEVEL = 100;

    public PartyMember(int _memberID, int _exp)
    {
        Character(_memberID);
        Exp = _exp;
        UpdateStats();
    }

    /// <summary>
    /// In case a character levels up, run this to update the character's maximum HP and Mana.
    /// </summary>
    public void UpdateStats()
    {
        for (int lv = 0; lv <= MAX_LEVEL; lv++)
        {
            if (Exp >= baseMaxExp * (lv * lv))
            {
                Level = lv;
            }
        }

        maxHP = Convert.ToInt32(baseHP * (Level * HPMultiplier));
        maxMana = Convert.ToInt32(baseMana * (Level * ManaMultiplier));
    }

    private void Character(int _IDnum)
    {
        switch (_IDnum)
        {
            case 1:
                Name = "Stanley";
                baseHP = 100;
                baseMana = 100;
                HPMultiplier = 1.1;
                ManaMultiplier = 0.8;
                break;
            case 2:
                Name = "Groose";
                baseHP = 100;
                baseMana = 100;
                HPMultiplier = 1.0;
                ManaMultiplier = 1.0;
                break;
            case 3:
                Name = "GT Goku";
                baseHP = 50;
                baseMana = 100;
                HPMultiplier = 1.5;
                ManaMultiplier = 1.2;
                break;
            case 4:
                Name = "Side-B Charizard";
                baseHP = 130;
                baseMana = 50;
                HPMultiplier = 1.25;
                ManaMultiplier = 0.5;
                break;
        }
    }

}
