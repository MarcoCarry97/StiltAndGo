using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharPlayerController : MonoBehaviour
{
    private CharacterController controller;

    [Range(1, 10)]
    public float fallSpeed;

    [Range(1, 10)]
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        print(controller.isTrigger);
        if (!controller.isTrigger)
            gameObject.transform.Translate(Vector2.down*fallSpeed*Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            controller.Move(Vector2.left * speed*Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            controller.Move(Vector2.right * speed*Time.deltaTime);
        
    }
}
