using System.Collections;
using System.Collections.Generic;
using ToolBox.Control.Explorer2D;
using UnityEngine;
using UnityEngine.EventSystems;
public class RightMovementButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Vector3 direction;

    private void Start()
    {
        direction = Vector3.zero;
    }

    private void Update()
    {
        Stilt stilt = GameObject.FindObjectOfType<Stilt>();
        CharacterController2D controller = stilt.GetComponent<CharacterController2D>();
        controller.Move(direction);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        direction = Vector3.right;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        direction = Vector3.zero;
    }


}
