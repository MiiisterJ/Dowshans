using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title_Buttons : MonoBehaviour
{
    bool setWorld = false;

    public Button startButton;
    public Button selectWorld;
    // Start is called before the first frame update
    void Start()
    {
        startButton = GameObject.Find("StartButton").GetComponent<Button>();
        startButton.onClick.AddListener(StartGame);

        selectWorld = GameObject.Find("SelectWorld").GetComponent<Button>();
        selectWorld.onClick.AddListener(ChangeWorld);
    }

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
