using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleMode : MonoBehaviour
{
    GameLogic gl;
    Enemy opponent;

    public int TestOutput;

    // Start is called before the first frame update
    void Start()
    {
        gl = FindObjectOfType<GameLogic>();
        opponent = FindObjectOfType<Enemy>();
        UIParty_Update();
        UIEnemy_Update();
        TestOutput = opponent.MonsterID;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        GameObject UIPanel;
        //Enemy UI
        if (opponent.EnemyAmount <= 1)
        {
            UIPanel = GameObject.Find("EnemyPanel 2");
            UIPanel.SetActive(false);
        }
        if (opponent.EnemyAmount <= 2)
        {
            UIPanel = GameObject.Find("EnemyPanel 3");
            UIPanel.SetActive(false);
        }
        if (opponent.EnemyAmount <= 3)
        {
            UIPanel = GameObject.Find("EnemyPanel Boss");
            UIPanel.SetActive(false);
        }
    }
}
