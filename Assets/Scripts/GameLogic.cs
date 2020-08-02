using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System;

/// Added minor descriptions by Jihad

#region Read Only Inspector
#if DEBUG
public class ReadOnlyAttribute : PropertyAttribute
{

}


[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property,
                                            GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, label, true);
    }

    public override void OnGUI(Rect position,
                               SerializedProperty property,
                               GUIContent label)
    {
        GUI.enabled = false;
        EditorGUI.PropertyField(position, property, label, true);
        GUI.enabled = true;
    }
}

#endif
#endregion

public class GameLogic : MonoBehaviour
{
    public GameObject Instance;

    public Scene ActiveScene;
    public string SceneName;
    public LoadSceneMode SceneMode;

    //Pause Stuff
    public GameObject pauseMenuPrefab;
#if DEBUG
    [ReadOnly] [SerializeField]
#endif
    bool Pause;
    bool escPress;
    public Button ContinueButt, TitleButt, ExitButt;

    public PartyMember[] Character = new PartyMember[4];

    int GameMode;
    public bool UpdateUI;

    //These are variables to tell the game logic to add in the game, such as button inputs, escape, pause, cotinue buttons and interconnect each scene with each other
#if DEBUG
    [ReadOnly] [SerializeField]
#endif
    int testOutput;


    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (Instance == null)
        {
            Instance = gameObject;
        }
        if (FindObjectsOfType<GameLogic>().Length != 1)
        {
            GameObject.Destroy(Instance);
        }

        //This script tells the game logic to destroy the other copy of a game logic if it duplicates

    }
    // Start is called before the first frame update
    void Start()
    {
        ContinueButt.onClick.AddListener(ContinueFunction);
        TitleButt.onClick.AddListener(TitleScreenFunction);
        ExitButt.onClick.AddListener(ExitFunction);

        testOutput++;
    }
    
    //This script tells the game logic to have functions that are clickable with exit button, title button and continue button

    // Update is called once per frame
    void Update()
    {
        ActiveScene = SceneManager.GetActiveScene();
        if (SceneName != ActiveScene.name)
        {
            SceneName = ActiveScene.name;
            if (SceneName == "Rocky Mountains" || SceneName == "Dark Castle")
                UI_Update();
        }

        if (UpdateUI)
        {
            //if (SceneName == "Rocky Mountains" || SceneName == "Dark Castle")
            UI_Update();
            testOutput++;
            UpdateUI = false;
        }

        PauseMenu();
    }
    
    //This tells the game logic to update the UI with Rocky Mountains level and the Dark Castle Level

    void LoadFile_ExperiencePoints()
    {

    }

    void UI_Update()
    {
        Text UITextBox;
        for (int i = 0; i < Character.Length; i++)
        {
            switch (Character[i].MemberID)
            {
                case 1:
                    UITextBox = GameObject.Find("Rocky UI").GetComponent<Text>();
                    UITextBox.text = Character[i].Name + " Lvl. " + Character[i].Level;
                    break;
                case 2:
                    UITextBox = GameObject.Find("Luke UI").GetComponent<Text>();
                    UITextBox.text = Character[i].Name + " Lvl. " + Character[i].Level;
                    break;
                case 3:
                    UITextBox = GameObject.Find("Jane UI").GetComponent<Text>();
                    UITextBox.text = Character[i].Name + " Lvl. " + Character[i].Level;
                    break;
                case 4:
                    UITextBox = GameObject.Find("Phoenix UI").GetComponent<Text>();
                    UITextBox.text = Character[i].Name + " Lvl. " + Character[i].Level;
                    break;
            }
        }
    }

    // This script tells the game logic to update the UI with the character portraits once they level up

    void PauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (escPress == false && Pause == false)
            {
                pauseMenuPrefab.SetActive(true);
                Pause = !Pause;
                escPress = true;
            }
            if (escPress == false && Pause == true)
            {
                pauseMenuPrefab.SetActive(false);
                Pause = !Pause;
                escPress = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            escPress = false;
        }

        if (SceneName == "Battle Scene")
        {
            TitleButt.enabled = false;
            TitleButt.GetComponent<Image>().color = Color.gray;
        }
        else
        {
            TitleButt.enabled = true;
            TitleButt.GetComponent<Image>().color = Color.white;
        }
    }

    //This script tells the game logic to enable each button input for escape, so when you press it during the world map you will be able to use it properly, but  if it's in the battle scene it won't do it properly

    void ExitFunction()
    { Application.Quit(); }

    void ContinueFunction()
    { pauseMenuPrefab.SetActive(false); Pause = false; }

    void TitleScreenFunction()
    { SceneManager.LoadScene("Title Screen"); pauseMenuPrefab.SetActive(false); Pause = false; }
}
//This script has the button function for the continue, exit and the title screen on the UI if you press it