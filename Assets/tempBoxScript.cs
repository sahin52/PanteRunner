using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempBoxScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {   
        print("box trigger " + col.gameObject.tag);
    }
}
