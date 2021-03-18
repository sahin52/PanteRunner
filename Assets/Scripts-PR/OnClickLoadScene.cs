using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class OnClickLoadScene : MonoBehaviour
{
    private Button yourButton;
    [SerializeField]
    private int sceneIndex = 0;
    void Start()
    {
        yourButton = this.GetComponent<Button>();
        yourButton.onClick.AddListener(LoadSceneWithNo);
    }

    void LoadSceneWithNo()
    {
        print("clicked");
        SceneManager.LoadScene(sceneIndex);
    }
}
