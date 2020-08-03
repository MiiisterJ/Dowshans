using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// Added minor descriptions by Jihad
public class Title_Buttons : MonoBehaviour
{
    bool setWorld = false;

    public Button startButton;
    public Button selectWorld;
    // Start is called before the first frame update

    // This is set to make the title function with buttons, such as Start and Selecting worlds
    void Start()
    {
        startButton = GameObject.Find("StartButton").GetComponent<Button>();
        startButton.onClick.AddListener(StartGame);

        selectWorld = GameObject.Find("SelectWorld").GetComponent<Button>();
        selectWorld.onClick.AddListener(ChangeWorld);
    }
    
    //This codes tells Unity to add a function to each of the buttons

    // Update is called once per frame
    void Update()
    {

    }

    void StartGame()
    {
        if (setWorld == false)
            SceneManager.LoadScene("Rocky Mountains");
        else
            SceneManager.LoadScene("Dark Castle");
    }

    // This script will tell Unity to load the scene once the button has been selected
    void ChangeWorld()
    {
        Text ButtText;
        setWorld = !setWorld;
        if (setWorld == false)
        {
            ButtText = GameObject.Find("SelectWorld/Text").GetComponent<Text>();
            ButtText.text = "World: Rocky Mountains";
        }
        else
        {
            ButtText = GameObject.Find("SelectWorld/Text").GetComponent<Text>();
            ButtText.text = "World: Dark Castle";
        }
    }
}

//This script tells unity to change the world when you click it on the button and load the scene.