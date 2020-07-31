using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System;

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


    }
    // Start is called before the first frame update
    void Start()
    {
        ContinueButt.onClick.AddListener(ContinueFunction);
        TitleButt.onClick.AddListener(TitleScreenFunction);
        ExitButt.onClick.AddListener(ExitFunction);

        testOutput++;
    }

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
    }

    void ExitFunction()
    { Application.Quit(); }

    void ContinueFunction()
    { pauseMenuPrefab.SetActive(false); Pause = false; }

    void TitleScreenFunction()
    { SceneManager.LoadScene("Title Screen"); pauseMenuPrefab.SetActive(false); Pause = false; }
}
