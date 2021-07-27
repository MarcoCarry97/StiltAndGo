using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RectGenerator : MonoBehaviour
{
    private Transform limitLeft;

    private float time;

    private bool end;

    public List<Color> colors;

    public RectangleSlide rect;

    [Range(3, 15)]
    public float maxRand;

    // Start is called before the first frame update
    void Start()
    {
        limitLeft = GameObject.FindGameObjectWithTag("LimitLeft").transform;
        time = 0.86f;
        end = false;
        //rect = Resources.Load<RectangleSlide>("Prefabs/Rectangle.prefab");
        StartCoroutine("RectGeneration");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator RectGeneration()
    {
        for(int i=0;i<25;i++)
        {
            yield return new WaitForSeconds(time);
            GenerateRect(rect.transform.localScale);
        }
        while(!end)
        {
            yield return new WaitForSeconds(time);
            Vector3 scale = GetScale();
            GenerateRect(scale);
        }
    }

    private Vector3 GetPosition()
    {
        Vector3 position = limitLeft.position;
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
        Vector3 scale= Vector3.one;
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
    }

    private void SetColor(RectangleSlide rectSlide)
    {
        Color color = GetColor();
        rectSlide.GetComponent<SpriteRenderer>().color = color;
    }
}

