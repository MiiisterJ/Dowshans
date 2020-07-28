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
    [ReadOnly] [SerializeField] int _maxHP;
    public int maxHP { get { return _maxHP; } private set { _maxHP = value; } }
    public int HP;

    [ReadOnly] [SerializeField] int _level;
    public int Level { get { return _level; } private set { if (value > 0) _level = value; } }

    int baseAtk;
    [ReadOnly] [SerializeField] int _attackPower;
    public int Stat_Attack { get { return _attackPower; } private set { _attackPower = value; } }

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
                    baseHP = 100;
                    baseAtk = 25;
                    break;
                case 2:
                    Name = "Boss2";
                    baseHP = 100;
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
                    Name = "Enemy3";
                    baseHP = 10;
                    baseAtk = 3;
                    break;

            }
    }
}
