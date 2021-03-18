using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartGameButtonScript : MonoBehaviour,IGameManagement
{
    [SerializeField]
    Button button;
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
    // Update is called once per frame
    void Update()
    {
        
    }


    void startGame()
    {
        PR_GameManager.gameManager.onStart();
    }
    public void OnFinish()
    {
        print("Restart game button On finish");
        SetIsActive(true);
        //throw new System.NotImplementedException();
    }

    public void OnLose()
    {
        print("Restart game button On Lose");
        SetIsActive(true);
        //throw new System.NotImplementedException();
    }

    public void OnPause()
    {
        print("Restart game button On Pause");
        SetIsActive(false);
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
        print("Restart game button On start");
        SetIsActive(true);
        //throw new System.NotImplementedException();
    }

}
