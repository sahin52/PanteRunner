using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BotScenestartGameButtonScript : MonoBehaviour
{
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(startGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void startGame()
    {
        FindObjectOfType<BotSceneGameManager>().isGamePlaying = true;
        button.gameObject.SetActive(false);
    }
}
