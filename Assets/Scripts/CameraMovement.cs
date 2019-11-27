using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] Transform playerTransform;
    [SerializeField] Tilemap tilemap;
    BoundsInt bounds;
    [SerializeField] float xMin;
    [SerializeField] float xMax;
    [SerializeField] float yMin;
    [SerializeField] float yMax;
    [SerializeField] int cellSize;
    Camera mainCamera;

    void Awake()
    {
        if (playerTransform == null)
        {
            Debug.LogError("Aj kurva pridek playerTransform kameroje");
            Debug.Log("Kamera iesko zaidejo...");

            try
            {
                playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            }
            catch
            {

            }

        }
        if (tilemap == null)
        {
            Debug.LogError("Pridek grida ");
        }
        else
        {
            mainCamera = GetComponent<Camera>();

            bounds = tilemap.cellBounds;

            float camHeight =  2f * mainCamera.orthographicSize;
            float camWidth = camHeight * mainCamera.aspect;

            xMin = (float)bounds.x + (camHeight / 2);
            xMax = (float)bounds.xMax - (camHeight / 2);
            yMin = (float)bounds.y + (camWidth / 4);
            yMax = (float)bounds.yMax - (camWidth / 4);

            Debug.Log(camWidth + " " + camHeight);

          

        }


    }

    // Update is called once per frame
    void Update()
    {



        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else
            MoveCamera();
    }

    void MoveCamera()
    {

        float playerX = playerTransform.position.x;
        float playerY = playerTransform.position.y;

        playerX = Mathf.Clamp(playerX, xMin, xMax);
        playerY = Mathf.Clamp(playerY, yMin, yMax);

        transform.SetPositionAndRotation(new Vector3(playerX, playerY, transform.position.z), Quaternion.identity);

      

    }
}
