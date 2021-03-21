using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpRightButtonScript : MonoBehaviour,IGameManagement
{
    [SerializeField]
    Sprite playImage,pauseImage;
    private Image buttonImage;
    private Button button;

    // Start is called before the first frame update
    void Awake() {
        buttonImage = this.GetComponent<Image>();
        button = GetComponent<Button>();
        button.onClick.AddListener(pauseGame);
    }
    void Start()
    {
        
        //button.onClick.AddListener(changeBGImage);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void pauseGame()
    {
        PR_GameManager.gameManager.onPause();
    }
    void changeBGImage()
    {
        if(buttonImage.sprite == pauseImage)
        {
            buttonImage.sprite = playImage;
        }
        else
        {
            buttonImage.sprite = pauseImage;
        }
    }

    public void OnFinish()
    {
        button.gameObject.SetActive(false);
        // throw new System.NotImplementedException();
    }

    public void OnLose()
    {
        button.gameObject.SetActive(false);
        //throw new System.NotImplementedException();
    }

    public void OnPause()
    {
        buttonImage.sprite = playImage;
        button.gameObject.SetActive(false);
        //throw new System.NotImplementedException();
    }

    public void OnPlay()
    {
        buttonImage.sprite = pauseImage;
        button.gameObject.SetActive(true);
        //throw new System.NotImplementedException();
    }

    public void OnStart()
    {
        buttonImage.sprite = playImage;
        button.gameObject.SetActive(false);
        //throw new System.NotImplementedException();
    }

    public void OnFinishLinePassed()
    {
        //throw new System.NotImplementedException();
    }
}
