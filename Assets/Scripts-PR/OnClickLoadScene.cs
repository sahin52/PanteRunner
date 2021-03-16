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
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(LoadSceneWithNo);
    }

    void LoadSceneWithNo()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
