using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{

    public string enterFrom;

    void Start()
    {
        if(enterFrom.Length == 0)
        {
            Debug.Log(this.name + ": nera scenos pavadinimo");
        }
    }

 
}
