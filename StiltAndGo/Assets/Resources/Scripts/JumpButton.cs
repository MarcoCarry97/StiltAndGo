using System.Collections;
using System.Collections.Generic;
using ToolBox.Control.Explorer2D;
using UnityEngine;
using UnityEngine.EventSystems;
public class JumpButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool canJump;

    private void Start()
    {
        canJump = false;
    }

    private void Update()
    {
        Stilt stilt = GameObject.FindObjectOfType<Stilt>();
        CharacterController2D controller = stilt.GetComponent<CharacterController2D>();
        controller.HighJump(canJump);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        canJump = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        canJump = false;
    }


}
