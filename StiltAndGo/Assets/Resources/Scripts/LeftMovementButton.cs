using System.Collections;
using System.Collections.Generic;
using ToolBox.Control.Explorer2D;
using UnityEngine;
using UnityEngine.EventSystems;
public class LeftMovementButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Vector3 direction;

    private CharacterController2D controller;

    private void Start()
    {
        Stilt stilt = GameObject.FindObjectOfType<Stilt>();
        controller = stilt.GetComponent<CharacterController2D>();
        direction = Vector3.zero;
    }

    private void Update()
    {
        Stilt stilt = GameObject.FindObjectOfType<Stilt>();
        CharacterController2D controller = stilt.GetComponent<CharacterController2D>();
        //controller.Move(direction);
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        controller.Move(Vector3.left);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        controller.Move(Vector3.zero);
    }


}
