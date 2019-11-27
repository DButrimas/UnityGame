using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Image cardImage;
    public Text description;
    public Text Name;
    //public GameObject c;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked"+ gameObject.name);
        Destroy(gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse enter");
        transform.localScale += new Vector3(1f, 1.5f, 0);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse exit");
        transform.localScale += new Vector3(-1f, -1.5f, 0);
    }


}