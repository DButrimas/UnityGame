using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{


    public Image dialogue_avatar;
    public Transform[] Points;
    public float Speed = 0.0f;
    public int current = 0;
    public bool isMoving = false;
    public Text pressButton;
    public static bool DialogueStart = false;
    public Dialogue dialogue;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        pressButton.enabled = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        pressButton.enabled = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Pressed E, starting dialogue");
            Dialogue_Manager.startDialogue(dialogue,dialogue_avatar);
        }
    }


    void Start () {

        if (isMoving)
        {
            if (Points.Length <= 0)
            {
                Debug.Log("bro you must add waypoints");
            }
            transform.position = Points[current].transform.position;
        }
	}

    void Update()
    {
        if (isMoving)
        {
            followWayPoints();
        }

    }

    private void followWayPoints()
    {
        if (current <= Points.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, Points[current].transform.position, Speed * Time.deltaTime);
            if (gameObject.transform.position == Points[current].transform.position)
            {
                current += 1;
            }
        }
        else
        {
            System.Array.Reverse(Points);
            current = 0;
        }
    }


}
