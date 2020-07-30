using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleMode : MonoBehaviour
{
    GameLogic gl;
    public EnemyStats opponent;

    public int TestOutput;

    public int dice;

    int BattleState;

    public List<int> UnitIndex = new List<int>();
    public int[] UnitRoll = new int[5]; // 1 to 4 are the party members. 5 is the enemy.
    public bool DebugRerollRNG;
    bool Reroll;

    // Start is called before the first frame update
    void Awake()
    {
        gl = FindObjectOfType<GameLogic>();
        opponent = FindObjectOfType<EnemyStats>();
        //TestOutput = opponent.enemyID;
        //UIParty_Update();
        //UIEnemy_Update();
        Turntable(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Reroll)
        {
            Reroll = false;
            Turntable(1);
        }

        if (DebugRerollRNG)
        {
            DiceRollSetOrder();
            DebugRerollRNG = false;
        }
    }

    int DiceRollSetOrder()
    {
        dice = Random.Range(1, 11);
        return dice;
    }

    void Turntable(int _state) //Each character taking turns
    {
        switch (_state)
        {
            case 1: //Sets a value for each unit. Higher the value, the first to make a move.
                for (int i = 0; i < UnitRoll.Length; i++)
                {
                    UnitRoll[i] = DiceRollSetOrder();
                }
                for (int f = 0; f < UnitRoll.Length; f++) //Checks if there's a tie in the dice roll.
                {
                    for (int l = 0; l < UnitRoll.Length; l++)
                    {
                        if (f != l) //Prevents the same index from comparing to each other.
                        {
                            if (UnitRoll[f] == UnitRoll[l])
                            {
                                UnitRoll[f] = DiceRollSetOrder();
                                UnitRoll[l] = DiceRollSetOrder();
                            }
                            if (UnitRoll[f] == UnitRoll[l])
                            {
                                Reroll = true;
                            }
                        }
                    }
                }
                break;
            case 2: //Set list of turns
                for (int d = 11; d > 0; d--)
                {
                    for (int i = 0; i < UnitRoll.Length; i++)
                    {
                        if (UnitRoll[i] == d)
                        {
                            UnitIndex.Add(3);
                        }
                    }
                }
                break;
        }
    }

    void StateCheck() // Swtich statement indicating what stat the battle is in.
    {
        switch (BattleState)
        {
            case 1: //Player or enemy turn

                break;
            case 2: //When a action is selected, activate action

                break;
            case 3: //Attack/Ability state. Calculate damage or healing.

                break;
            case 4: //End turn state. Switch to next person.

                break; 
        }
    }

    void UIParty_Update()
    {
        Text UITextBox;
        for (int i = 0; i < 4; i++)
        {
            //Party Member UI
            switch (gl.Character[i].MemberID)
            {
                case 1:
                    UITextBox = GameObject.Find("Panel A/Name").GetComponent<Text>();
                    UITextBox.text = gl.Character[i].Name + " Lvl. " + gl.Character[i].Level;
                    UITextBox = GameObject.Find("Panel A/HP/Value").GetComponent<Text>();
                    UITextBox.text = gl.Character[i].HP + " / " + gl.Character[i].maxHP;
                    UITextBox = GameObject.Find("Panel A/Mana/Value").GetComponent<Text>();
                    UITextBox.text = gl.Character[i].Mana + " / " + gl.Character[i].maxMana;
                    break;
                case 2:
                    UITextBox = GameObject.Find("Panel B/Name").GetComponent<Text>();
                    UITextBox.text = gl.Character[i].Name + " Lvl. " + gl.Character[i].Level;
                    UITextBox = GameObject.Find("Panel B/HP/Value").GetComponent<Text>();
                    UITextBox.text = gl.Character[i].HP + " / " + gl.Character[i].maxHP;
                    UITextBox = GameObject.Find("Panel B/Mana/Value").GetComponent<Text>();
                    UITextBox.text = gl.Character[i].Mana + " / " + gl.Character[i].maxMana;
                    break;
                case 3:
                    UITextBox = GameObject.Find("Panel C/Name").GetComponent<Text>();
                    UITextBox.text = gl.Character[i].Name + " Lvl. " + gl.Character[i].Level;
                    UITextBox = GameObject.Find("Panel C/HP/Value").GetComponent<Text>();
                    UITextBox.text = gl.Character[i].HP + " / " + gl.Character[i].maxHP;
                    UITextBox = GameObject.Find("Panel C/Mana/Value").GetComponent<Text>();
                    UITextBox.text = gl.Character[i].Mana + " / " + gl.Character[i].maxMana;
                    break;
                case 4:
                    UITextBox = GameObject.Find("Panel D/Name").GetComponent<Text>();
                    UITextBox.text = gl.Character[i].Name + " Lvl. " + gl.Character[i].Level;
                    UITextBox = GameObject.Find("Panel D/HP/Value").GetComponent<Text>();
                    UITextBox.text = gl.Character[i].HP + " / " + gl.Character[i].maxHP;
                    UITextBox = GameObject.Find("Panel D/Mana/Value").GetComponent<Text>();
                    UITextBox.text = gl.Character[i].Mana + " / " + gl.Character[i].maxMana;
                    break;
            }
        }

    }

    void UIEnemy_Update()
    {
        Text UITextBox;
        //Enemy UI
        UITextBox = GameObject.Find("EnemyPanel/Name").GetComponent<Text>();
        UITextBox.text = opponent.Name;
        UITextBox = GameObject.Find("EnemyPanel/HP/Value").GetComponent<Text>();
        UITextBox.text = opponent.HP + " / " + opponent.maxHP;



    }
}
