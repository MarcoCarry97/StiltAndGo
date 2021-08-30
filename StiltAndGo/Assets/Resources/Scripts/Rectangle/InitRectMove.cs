using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitRectMove : MonoBehaviour
{
    public bool isMoving;

    [Range(1, 150)]
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
    }

    private void UpdatePosition()
    {
        Vector3 pos = this.transform.position;
        pos.x -= speed * Time.deltaTime;
        this.transform.position = pos;
    }

    

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            UpdatePosition();
        }
    }
}
