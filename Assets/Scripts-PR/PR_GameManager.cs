using UnityEngine;
using UnityEngine.UI;
using System.Linq;
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

    public static PR_GameManager gameManager;

    IGameManagement[] objectsAttachedToGameManagement;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<PR_GameManager>();
        var a = FindObjectsOfType<Object>().OfType<IGameManagement>();
        print(a);
        objectsAttachedToGameManagement = a.ToArray();
        print("printe");
        if (Player == null)
            Player = FindObjectOfType<PlayerController>();
        endGameText.text = "";
        finishGameButton.gameObject.SetActive(false);
        onStart();
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
            //startButtonText.text = "start game";
        }
        else
        {
            gameStarted = true;
            //startButtonText.text = "pause game";
        }
    }

    public void Restart()
    {
        Player.Restart();
        finishGameButton.gameObject.SetActive(false);
        endGameText.text = "";
        gameStarted = true;
    }
    public void onStart()
    {
        gameStarted = false;
        foreach(var temp in objectsAttachedToGameManagement)
        {
            temp.OnStart();
        }
    }
    public void onPlay()
    {
        gameStarted = true;
        foreach (var temp in objectsAttachedToGameManagement)
        {
            temp.OnPlay();
        }
    }
    public void onPause()
    {
        gameStarted = false;
        foreach (var temp in objectsAttachedToGameManagement)
        {
            temp.OnPause();
        }
    }
    public void onFinish()
    {
        gameStarted = false;
        foreach (var temp in objectsAttachedToGameManagement)
        {
            temp.OnFinish();
        }
    }
    public void onLose()
    {
        gameStarted = false;
        foreach (var temp in objectsAttachedToGameManagement)
        {
            temp.OnLose();
        }
    }


}
