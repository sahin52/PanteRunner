using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PR_GameManager : MonoBehaviour
{
    public bool gameStarted = false;
    [SerializeField]
    Text startButtonText;
    [SerializeField]
    Text endGameText;
    [SerializeField]
    Button finishGameButton;
    [SerializeField]
    PlayerController Player;
    // Start is called before the first frame update
    void Start()
    {
        if (Player == null)
            Player = FindObjectOfType<PlayerController>();
        endGameText.text = "";
        finishGameButton.gameObject.SetActive(false);

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
            startButtonText.text = "start game";
        }
        else
        {
            gameStarted = true;
            startButtonText.text = "pause game";
        }
    }
    public void onFinish()
    {
        endGameText.text = "Bolum bitti\nTebrikler";
        finishGameButton.gameObject.SetActive(true);
    }
    public void Restart()
    {
        Player.Restart();
        finishGameButton.gameObject.SetActive(false);
        endGameText.text = "";
    }
}
