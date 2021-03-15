using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PR_GameManager : MonoBehaviour
{
    public bool gameStarted = false;
    public bool gameFinished = false;
    [SerializeField]
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateGameState()
    {
        if (gameStarted)
        {
            gameStarted = false;
            text.text = "start game";
        }
        else
        {
            gameStarted = true;
            text.text = "pause game";
        }
    }
    public void finishGame()
    {
        gameFinished = true;
    }
}
