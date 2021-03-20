using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputTests : MonoBehaviour
{
    PlayerInputManager playerInputs;

    
    // Start is called before the first frame update
    void Start()
    {
        playerInputs = GetComponent<PlayerInputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        print("leftRight = " + playerInputs.leftRight());
        Debug.LogWarning("jump = " + playerInputs.jumpInput());
        Debug.LogWarning("slide = " + playerInputs.slideInput());
    }
}
