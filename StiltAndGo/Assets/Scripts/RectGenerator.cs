using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RectGenerator : MonoBehaviour
{
    private Transform limitLeft;

    [Range(1,50)]
    public float time;

    [Range(1, 50)]
    public float space;

    private bool end;

    public List<Color> colors;

    public RectangleSlide rect;

    public bool isMoving;
    private bool isOn;

    [Range(3, 15)]
    public float maxRand;

    public Transform lastRect;

    private int count;

    // Start is called before the first frame update
    void Start()
    {
        limitLeft = GameObject.FindGameObjectWithTag("LimitLeft").transform;
        lastRect = null;
        end = false;
        isMoving = false;
        isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
       if(isMoving && !isOn)
        {
            StartCoroutine(RectGeneration());
            isOn = true;
        }
    }

    public IEnumerator RectGeneration()
    {
        for(int i=0;i<25;i++)
        {
            yield return new WaitForSeconds(time/10);
            GenerateRect(rect.transform.localScale);
            count++;
        }
        while(!end)
        {
            yield return new WaitForSeconds(time/10);
            Vector3 scale = GetScale();
            GenerateRect(scale);
            count++;
        }
    }

    private Vector3 GetPosition()
    {
        Vector3 position = limitLeft.position;
        if (lastRect != null)
        {
            position = lastRect.position;
            position.x += lastRect.localScale.x*7;
        }
        position.y -= 4;
        return position;
    }

    private Quaternion GetRotation()
    {
        Quaternion rotation = limitLeft.rotation;
        return rotation;
    }

    private Vector3 GetScale()
    {
        Vector3 scale = rect.transform.localScale;
        scale.y = Random.Range(3,maxRand);
        return scale;
    }

    private Color GetColor()
    {
        int index = Random.Range(0, colors.Count);
        return colors[index];
    }
    private void GenerateRect(Vector3 scale)
    {
        Vector3 position = GetPosition();
        Quaternion rotation = GetRotation();
        RectangleSlide rectSlide = GameObject.Instantiate<RectangleSlide>(rect, position, rotation);
        rectSlide.transform.localScale = scale;
        SetColor(rectSlide);
        float speed = space / time;
        RectangleSlide.Speed = speed / 2;
        lastRect = rectSlide.transform;
    }

    private void SetColor(RectangleSlide rectSlide)
    {
        Color color = GetColor();
        rectSlide.GetComponent<SpriteRenderer>().color = color;
    }

    public void StopGeneration()
    {
        end = true;
    }
}

