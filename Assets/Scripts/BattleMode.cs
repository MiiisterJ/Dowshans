using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleMode : MonoBehaviour
{
    GameLogic gl;
    public EnemyStats opponent;

    public int TestOutput;

    public int rng;

    int BattleState;

    public bool RerollRNG;

    // Start is called before the first frame update
    void Awake()
    {
        gl = FindObjectOfType<GameLogic>();
        opponent = FindObjectOfType<EnemyStats>();
        //TestOutput = opponent.enemyID;
        //UIParty_Update();
        //UIEnemy_Update();

    }

    // Update is called once per frame
    void Update()
    {
        if (RerollRNG)
        {
            Turntable();
            RerollRNG = false;
        }
    }

    void DiceRollSetOrder()
    {

    }

    void Turntable() //Each character taking turns
    {
        rng = Random.Range(1, 6);
    }

    void StateCheck() // Swtich statement indicating what stat the battle is in.
    {
        switch (BattleState)
        {
            case 1: //Player or enemy turn
                break;
            case 2: //Attack/Ability state. Calculate damage or healing.
                break;
            case 3: //End turn state. Switch to next person.
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
