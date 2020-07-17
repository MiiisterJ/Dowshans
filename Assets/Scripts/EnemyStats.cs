using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Do NOT apply this to a game object. This is called by the Enemy script.
/// 
/// Coded by Max Seward (1TheBlueWii1)
/// </summary>
public class EnemyStats : MonoBehaviour
{
    public string Name { get; private set; }


    int baseHP;
    public int maxHP { get; private set; }
    public int HP;

    public int Level { get; private set; }

    int baseAtk;
    public int Stat_Attack { get; private set; }

    public EnemyStats(int _enemyID, bool _IsBoss, int _setLevel)
    {
        Creature(_enemyID, _IsBoss);
        Level = _setLevel;

        //Set maximum stats
        maxHP = baseHP * Level;
        Stat_Attack = baseAtk * Level;
    }

    /// <summary>
    /// Profiles of enemies.
    /// </summary>
    /// <param name="_IDnum"></param>
    /// <param name="_Boss">Is this enemy a boss? True/False</param>
    private void Creature(int _IDnum, bool _Boss)
    {
        if (_Boss)
            switch (_IDnum)
            {
                case 1:
                    Name = "Boss1";
                    baseHP = 1000;
                    baseAtk = 25;
                    break;
                case 2:
                    Name = "Boss2";
                    baseHP = 1000;
                    baseAtk = 25;
                    break;
            }
        else
            switch (_IDnum)
            {
                case 1:
                default:
                    Name = "Enemy1";
                    baseHP = 10;
                    baseAtk = 3;
                    break;
                case 2:
                    Name = "Enemy2";
                    baseHP = 10;
                    baseAtk = 3;
                    break;
                case 3:
                    Name = "";
                    baseHP = 10;
                    baseAtk = 3;
                    break;
                case 4:
                    Name = "";
                    baseHP = 10;
                    baseAtk = 3;
                    break;
                case 5:
                    Name = "";
                    baseHP = 10;
                    baseAtk = 3;
                    break;

            }
    }
}
