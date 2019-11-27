using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Skriptas, skirtas perkelti zaideja is vienos scenos i kita, kai jis prieina iejima/isejima
public class LevelChanger : MonoBehaviour
{

    [SerializeField] private string enterTo;       // scenos pavadinimas, i kuria nukels
    //static SceneData sceneData;
    PlayerSpawner playerSpawner;


    void Start()
    {
        playerSpawner = GameObject.Find("PlayerSpawner").GetComponent<PlayerSpawner>();

       // sceneData = new SceneData();

        if(enterTo.Length == 0)
        {
            Debug.LogError("ay blet scenos pavadinima irasyk");
        }

        


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Transform>().tag == "Player")
        {
            Debug.Log("succ");
            playerSpawner.firstSpawn = false;
            LoadScene(enterTo);
        }
    }
   

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public string GetDestination()
    {
        return enterTo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
