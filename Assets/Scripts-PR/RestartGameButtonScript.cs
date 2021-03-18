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
    }

    private void SetIsActive(bool value)
    {
        button.gameObject.SetActive(value);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnFinish()
    {
        SetIsActive(true);
        //throw new System.NotImplementedException();
    }

    public void OnLose()
    {
        SetIsActive(true);
        //throw new System.NotImplementedException();
    }

    public void OnPause()
    {
        SetIsActive(false);
        //throw new System.NotImplementedException();
    }

    public void OnPlay()
    {
        SetIsActive(false);
        //throw new System.NotImplementedException();
    }

    public void OnStart()
    {
        SetIsActive(true);
        //throw new System.NotImplementedException();
    }

}
