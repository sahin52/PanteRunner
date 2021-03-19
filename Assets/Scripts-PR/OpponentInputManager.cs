using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentInputManager : MonoBehaviour,IInputManager
{
    public bool jumpInput()
    {
        print("Opponent input jump is not set");
        return false;
        //throw new System.NotImplementedException();
    }

    public float leftRight()
    {
        print("Opponent leftRight input is not set");
        //throw new System.NotImplementedException();
        return 0;
    }

    public bool slideInput()
    {
        print("Opponent slide input is not set");
        //throw new System.NotImplementedException();
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
