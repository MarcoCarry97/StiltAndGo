using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleSlide : MonoBehaviour
{
    public static float Speed { get; set; }

    private Transform limitRight;

    // Start is called before the first frame update
    void Start()
    {
        limitRight = GameObject.FindGameObjectWithTag("LimitRight").transform;
        InitializePosition();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        Vector3 pos = this.transform.position;
        pos.x -= Speed*Time.deltaTime;
        this.transform.position = pos;
    }

    private void InitializePosition()
    {
        Vector3 pos = limitRight.transform.position;
        pos.y -= 4;
        this.transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("LimitLeft"))
            Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        GameState.Instance.AddPoints(100);

    }
}
