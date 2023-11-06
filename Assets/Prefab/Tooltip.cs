using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tooltip : MonoBehaviour //, IPointerEnterHandler, IPointerExitHandler
{
    public string message;
    private void OnMouseEnter()
    {
        Tooltipmanager._instance.SetAndShowToolTip(message);
    }

    private void OnMouseExit()
    {
        Tooltipmanager._instance.HideToolTip();
    }


    /*public void OnPointerEnter(PointerEventData pointerEventData)
    {
        Tooltipmanager._instance.SetAndShowToolTip(message);
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        Tooltipmanager._instance.HideToolTip();
    }*/
    //=======================================For Buttons=========================
}