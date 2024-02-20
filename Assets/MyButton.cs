using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MyButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public bool buttonPressed;
    public int direction;

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;

        AdditionalFunctionaning.instance.MoveCamera(direction, buttonPressed);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
        AdditionalFunctionaning.instance.MoveCamera(direction, buttonPressed);
    }
}