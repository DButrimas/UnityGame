using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// spawnina zaideja 
public class PlayerSpawner : MonoBehaviour
{

    [SerializeField] private string playerPrefabPath;
    private GameObject playerObject;
    static SceneData sceneData;
    [SerializeField] public bool firstSpawn { get; set; }
    [SerializeField] Vector3 spawnPoint;
    [SerializeField] string previousScene;
    [SerializeField] string sceneName;
    [SerializeField] Vector3 primarySpawn;
    

    // 
    void Awake()
    {
        GameObject[] spawners = GameObject.FindGameObjectsWithTag("PlayerSpawner");

        sceneName = SceneManager.GetActiveScene().name;

        // tikrinam, ar scenoje yra kiti PlayerSpawner objektai
        // jeigu yra, juos istrinam
        if (spawners.Length > 1)
        {
            for (int i = 1; i <= spawners.Length; i++)
            {
                Destroy(spawners[i].gameObject);
            }
        }
        Debug.Log("penis");
        DontDestroyOnLoad(this);                            // sitas objektas visada bus aktyvus, net ir keiciant scena
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform.position;
        primarySpawn = GameObject.FindGameObjectWithTag("PrimarySpawn").transform.position;

    }

    void Start()
    {

        firstSpawn = true;

        if (playerPrefabPath.Length == 0)
            Debug.LogError("nera zaidejo prefab nuorodos");

        else if (!firstSpawn)
        {
            SpawnPlayer();
        }



    }

    private Vector3 GetSpawnPoint()
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        Vector3 position = Vector3.zero;

        foreach(GameObject point in spawnPoints)
        {
            if(point.GetComponent<SpawnPoint>().enterFrom == previousScene)
            {
                position = point.GetComponent<Transform>().position;
                break;
            }
        }

        return position;
    }

    public void SpawnPlayer()
    {
        UnityEngine.Object playerPrefab;

        if ((playerPrefab = Resources.Load(playerPrefabPath)) == null)
        {
            Debug.LogError("neranda zaidejo prefabo");
        }
        else if(firstSpawn)
        {
            playerObject = (GameObject)GameObject.Instantiate(playerPrefab, primarySpawn, Quaternion.identity);
        }
        else
        {
            playerObject = (GameObject)GameObject.Instantiate(playerPrefab, GetSpawnPoint(), Quaternion.identity);
        }
    }

    private void FixedUpdate()
    {
        string tempScene = SceneManager.GetActiveScene().name;

        if (sceneName != tempScene)
        {
            //spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform.position;
            previousScene = sceneName;
            sceneName = tempScene;
        }
        if (!GameObject.FindGameObjectWithTag("Player"))
        {
            SpawnPlayer();
        }
    }
}
