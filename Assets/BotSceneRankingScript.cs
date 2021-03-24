using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BotSceneRankingScript : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] GameObject[] players;
    // Start is called before the first frame update
    void Start()
    {
        if (text == null)
        {
            text = GetComponent<Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetText();
    }
    private void SetText()
    { //Greater z means better ranking
        var zValues = new ArrayList();
        var playerArray = new ArrayList();
        foreach(var player in players){
            playerArray.Add(player);
        }
        GameObjectRankComparer myComparer = new GameObjectRankComparer();
        Array.Sort(players, myComparer);
        var total = players.Length;
        var myRank = total;
        foreach (var player in players)
        {
            //playerArray.Add(player);
            if(player.gameObject.tag == Constants.Tags.Player)
            {
                break;
            }
            myRank--;
        }
        text.text = "RANK: "+myRank + "/"+total;
    }
    
}
public class GameObjectRankComparer : IComparer<GameObject>
{
    public int Compare(GameObject a, GameObject b)
    {
        if ((a.transform.position.z == b.transform.position.z) && (a.transform.position.z == b.transform.position.z))
            return 0;
        if (a.transform.position.z < b.transform.position.z)
            return -1;

        return 1;
    }
}
