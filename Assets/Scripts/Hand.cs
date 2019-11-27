using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hand : MonoBehaviour
{
    public static List<GameObject> myHand = new List<GameObject>();
    private static int maxHandSize = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static bool isFull()
    {
        if(myHand.Count >= maxHandSize)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
