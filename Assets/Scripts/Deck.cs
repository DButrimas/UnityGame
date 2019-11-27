using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<GameObject> myDeck = new List<GameObject>();

    int maxCardsNumber = 12;

    public GameObject card1;
    public GameObject card2;
    public GameObject card3;
    public GameObject card4;
    public GameObject card5;
    public GameObject card6;
    public GameObject card7;
    public GameObject card8;
    public GameObject card9;
    public GameObject card10;
    public GameObject card11;
    public GameObject card12;

    // Start is called before the first frame update
    void Start()
    {
        if(card1 != null)
        {
            myDeck.Add(card1);
        }
        if (card2 != null)
        {
            myDeck.Add(card2);
        }
        if (card3 != null)
        {
            myDeck.Add(card3);
        }
        if (card4 != null)
        {
            myDeck.Add(card4);
        }
        if (card5 != null)
        {
            myDeck.Add(card5);
        }
        if (card6 != null)
        {
            myDeck.Add(card6);
        }
        if (card7 != null)
        {
            myDeck.Add(card7);
        }
        if (card8 != null)
        {
            myDeck.Add(card8);
        }
        if (card9 != null)
        {
            myDeck.Add(card9);
        }
        if (card10 != null)
        {
            myDeck.Add(card10);
        }
        if (card11 != null)
        {
            myDeck.Add(card11);
        }
        if (card12 != null)
        {
            myDeck.Add(card12);
        }
    }

    public void drawCard()
    {
        if (Input.GetMouseButtonDown(0)) //testavimui, kortos turi but traukiamos savo ejimo pradzioj
        {
            Debug.Log("Pressed primary button.");
            if (myDeck.Count <= 0)
            {
                Debug.Log("Deck is empty");
                return;
            }
            if (Hand.isFull())
            {
                Debug.Log("Hand is full, cant draw play animation and show message or some shit idk");
            }
            else
            {
                int index = Random.Range(0, myDeck.Count);
                GameObject test = Instantiate(myDeck[index], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                test.transform.parent = GameObject.Find("Hand").transform;
                Hand.myHand.Add(myDeck[index]);
                myDeck.Remove(myDeck[index]);
                myDeck.Sort();
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        drawCard();

    }


}
