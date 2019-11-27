using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Manager : MonoBehaviour
{
    public Image dialogue_panel;
    public Text dialogue_text;
    public static Dialogue tempDialogue;
    int index;
    public static bool start = false;
    public bool dialogue_running = false;
    public Animator animator;
    public float seconds;
    public Image player_avatar;

    public bool player_talking = false;

    //  public Image choicePanel;
     public Image finger;
     public Image choice_yes;
     public Image choice_no;

    public Image[] choices_array;
    public int choiceIndex = 0;


    public Canvas choice_canvas;

    public Image dialogue_avatar_img;
    public static Image dialogue_avatar_temp;

    public bool finishedTyping = false;




    public static void startDialogue(Dialogue dialogue,Image dialogue_avatar)
    { 
        dialogue_avatar_temp = dialogue_avatar;
        tempDialogue = dialogue;
        start = true;
    }
    public void run_dialogue()
    {
        dialogue_panel.enabled = true;
        dialogue_avatar_img.enabled = true;
        player_avatar.enabled = true;
        animator.SetBool("isOpen",true);
        dialogue_avatar_img.sprite = dialogue_avatar_temp.sprite;
        StartCoroutine(Type());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(seconds);
    }
    IEnumerator Type()
    {
        if (tempDialogue.sentences[index].Contains("[P]"))
        {
          // tempDialogue.sentences[index] = tempDialogue.sentences[index].Replace("[P]","");
           playerTalking();
            yield return StartCoroutine(Wait());
            foreach (char letter in tempDialogue.sentences[index].Replace("[P]","").ToCharArray())
            {
                dialogue_text.text += letter;
                yield return new WaitForSeconds(0.05f);
            }
            finishedTyping = true;
        }
        else
        {
            enemyTalking();
            yield return StartCoroutine(Wait());
            foreach (char letter in tempDialogue.sentences[index].ToCharArray())
            {
                dialogue_text.text += letter;
                yield return new WaitForSeconds(0.05f);
            }
            finishedTyping = true;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (var a in choices_array)
        {
            a.color = Color.grey;
        }
        choices_array[index].color = Color.red;

        choice_canvas.enabled = false;
        dialogue_panel.enabled = false;
        dialogue_avatar_img.enabled = false;
        player_avatar.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (start == true)
        {
            run_dialogue();
            start = false;
            dialogue_running = true;
        }
        if (dialogue_running && Input.GetKeyDown(KeyCode.Space) && finishedTyping == true)
        {
            if (index != tempDialogue.sentences.Length - 1)
            {
                finishedTyping = false;
                index++;
                dialogue_text.text = "";
                StartCoroutine(Type());
            }
        }
        if (dialogue_running && Input.GetKeyDown(KeyCode.Escape))
        {
            animator.SetBool("isOpen", false);
            dialogue_running = false;
            index = 0;
            dialogue_text.text = "";
            dialogue_avatar_img.sprite = null;
            dialogue_avatar_img.enabled = false;
            player_avatar.enabled = false;
            choice_canvas.enabled = false;
            finishedTyping = false;

        }
        if (index == tempDialogue.sentences.Length - 1 && finishedTyping)
        {         
            showChoices();
        }
    }

    public void playerTalking()
    {

        Debug.Log("player talking");
        var tempColor = player_avatar.color;
        tempColor.a = 1f;
        player_avatar.color = tempColor;

        var tempColorEnemy = dialogue_avatar_img.color;
        tempColor.a = 0.6f;
        dialogue_avatar_img.color = tempColor;
    }
    public void enemyTalking()
    {

        Debug.Log("enemy talking");
        var tempColor = player_avatar.color;
        tempColor.a = 0.6f;
        player_avatar.color = tempColor;

        var tempColorEnemy = dialogue_avatar_img.color;
        tempColor.a = 1f;
        dialogue_avatar_img.color = tempColor;
    }
    






    public void showChoices()
    {

        finger.transform.position = new Vector2(finger.transform.position.x,choices_array[choiceIndex].transform.position.y);
        choice_canvas.enabled = true;

        Color colorHighlighted = Color.red;


        Color notHighlighted = Color.grey;



        if (Input.GetKeyDown(KeyCode.S)){
            if (choiceIndex < choices_array.Length -1)
            {
                choices_array[choiceIndex].color = notHighlighted;
                choiceIndex++;
                finger.transform.position = new Vector2(finger.transform.position.x, choices_array[choiceIndex].transform.position.y);
                choices_array[choiceIndex].color = colorHighlighted;
            }
            else
            {
                choices_array[choiceIndex].color = notHighlighted;
                choiceIndex = 0;
                finger.transform.position = new Vector2(finger.transform.position.x, choices_array[choiceIndex].transform.position.y);
                choices_array[choiceIndex].color = colorHighlighted;
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (choiceIndex > 0)
            {
                choices_array[choiceIndex].color = notHighlighted;
                choiceIndex--;
                finger.transform.position = new Vector2(finger.transform.position.x, choices_array[choiceIndex].transform.position.y);
                choices_array[choiceIndex].color = colorHighlighted;
            }
            else
            {
                choices_array[choiceIndex].color = notHighlighted;
                choiceIndex = choices_array.Length - 1;
                finger.transform.position = new Vector2(finger.transform.position.x, choices_array[choiceIndex].transform.position.y);
                choices_array[choiceIndex].color = colorHighlighted;
            }
        }
    }

    public void highlightChoices(Color highghlighted, Color notHighlighted)
    {
        foreach (var a in choices_array)
        {
            if (a == choices_array[choiceIndex])
            {
                choices_array[choiceIndex].color = highghlighted;
            }
            else
            {
                choices_array[choiceIndex].color = notHighlighted;
            }
        }
    }

}
