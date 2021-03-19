using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartGameButtonScript : MonoBehaviour,IGameManagement
{
    [SerializeField]
    Button button;
    [SerializeField]
    Text textOnButton,textAboveButton;
    // Start is called before the first frame update
    void Start()
    {
        if(button ==null)
            button = GetComponent<Button>();
        button.onClick.AddListener(startGame);
    }

    private void SetIsActive(bool value)
    {
        button.gameObject.SetActive(value);
    }

    void startGame()
    {
        PR_GameManager.gameManager.onStart();
    }
    void continueGame()
    {
//#if UNITY_EDITOR
//        UnityEditor.EditorApplication.isPaused = true;
//#endif
        PR_GameManager.gameManager.onPlay();


    }
    public void OnFinish()
    {
        print("Restart game button On finish");
        textAboveButton.text = "Congragulations!";
        textOnButton.text = "Restart";
        SetIsActive(true);
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(startGame);
        //throw new System.NotImplementedException();
    }

    public void OnLose()
    {
        print("Restart game button On Lose");
        textAboveButton.text = "Unfortunately Lost!";
        textOnButton.text = "Restart";
        SetIsActive(true);
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(startGame);
        //throw new System.NotImplementedException();
    }

    public void OnPause()
    {
        print("Restart game button On Pause");
        textAboveButton.text = "Game Paused!";
        textOnButton.text = "Continue";
        SetIsActive(true);
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(continueGame);
    //throw new System.NotImplementedException();
    }

    public void OnPlay()
    {
        print("Restart game button On play");
        SetIsActive(false);
        //throw new System.NotImplementedException();
    }

    public void OnStart()
    {
        textAboveButton.text = "Avoid The Obstacles!";
        textOnButton.text = "Start";
        print("Restart game button On start");
        SetIsActive(true);
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(continueGame);
    //throw new System.NotImplementedException();
    }

}
