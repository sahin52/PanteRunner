using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class BotSceneGameManager : MonoBehaviour
{
    public BotSceneGameManager gameManager;
    // Start is called before the first frame update
    IGameManagement[] objectsAttachedToGameManagement;

    [SerializeField] private Text endGameText;
    [SerializeField] private Text rankText;


    public bool isGamePlaying = false;
    void Awake()
    {
        isGamePlaying = false;
        gameManager = this;
        objectsAttachedToGameManagement = FindObjectsOfType<UnityEngine.Object>().OfType<IGameManagement>().ToArray();
        if (gameManager == null)
            gameManager = FindObjectOfType<BotSceneGameManager>();
    }
    public void EndGame()
    {
        endGameText.text = rankText.text;
    }
    void Start()
    {
        endGameText.text = "";
        onStart();
    }

    void onStart()
    {
        foreach (var managedObject in objectsAttachedToGameManagement)
        {
            managedObject.OnStart();
        }
    }
    public void onPlay()
    {
        isGamePlaying = true;
        foreach (var temp in objectsAttachedToGameManagement)
        {
            temp.OnPlay();
        }
    }
    public void onPause()
    {
        isGamePlaying = false;
        foreach (var temp in objectsAttachedToGameManagement)
        {
            temp.OnPause();
        }
    }
    public void onFinish()
    {
        isGamePlaying = false;
        foreach (var temp in objectsAttachedToGameManagement)
        {
            temp.OnFinish();
        }
    }
    public void onLose()
    {
        isGamePlaying = false;
        foreach (var temp in objectsAttachedToGameManagement)
        {
            temp.OnLose();
        }
    }
    public void onFinishLinePassed()
    {
        foreach (var temp in objectsAttachedToGameManagement)
        {
            temp.OnFinishLinePassed();
        }
    }

}
