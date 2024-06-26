using System.Collections;
using System.Collections.Generic;
using ToolBox.Control.Explorer2D;
using UnityEngine;

public class Rectangle : MonoBehaviour
{
    // Start is called before the first frame update

    [Range(1, 100)]
    public float speed;

    private bool _ready = false;

    private Rigidbody2D rigidbody;

    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
        _ready= true;
        rigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 vector = new Vector3(speed*3.5f, 0,0);
        vector *= Time.fixedDeltaTime*-1;
        Vector3 pos = this.transform.position;
        //_rigidBody.velocity = vector;
        rigidbody.MovePosition(pos+vector);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("LimitLeft"))
        {
            RectGenerator gen = GameObject.FindGameObjectWithTag("Generator")
                .GetComponent<RectGenerator>();
            if (gen.GetState() == RectGenerator.GenState.Init)
                gen.SetState(RectGenerator.GenState.Normal);
            this.gameObject.SetActive(false);
            this.transform.localScale = originalScale;
            gen.Add(this);
        }
    }

    public Transform Next()
    {
        return this.transform.GetChild(1);
    }

    public Transform ObjectPoint()
    {
        return this.transform.GetChild(0);
    }

    public bool isReady()
    {
        return _ready;
    }
}
