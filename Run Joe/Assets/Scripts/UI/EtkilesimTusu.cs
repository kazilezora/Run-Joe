using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EtkilesimTusu : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public bool basilimi;
    public void OnPointerDown(PointerEventData eventData)
    {
        basilimi = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        basilimi = false;
    }
}
