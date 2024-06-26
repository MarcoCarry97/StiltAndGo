using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;
using ToolBox.Core;

public class RectGenerator : MonoBehaviour
{
    public enum GenState
    {
        First,
        Init,
        Normal,
        Play,
        End
    }

    [SerializeField]
    [Range(10, 100)]
    private int numOfRectanglesOnScene = 10;

    private List<Rectangle> rectanglesInScene;

    private GenState _state;
    private Collider2D _left;
    private Collider2D _right;

    private GameObject _rect;
    private Rectangle _last;

    private bool _playerGenerated;

    private List<Color> colours;

    public int Points { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        colours = new List<Color>();
        colours.Add(Color.white);
        colours.Add(Color.black);
        colours.Add(Color.red);
        colours.Add(Color.green);
        colours.Add(Color.blue);
        colours.Add(Color.yellow);
        _playerGenerated = false;
        _state=GenState.First;
        _left = GameObject.FindGameObjectWithTag("LimitLeft").GetComponent<Collider2D>();
        _right = GameObject.FindGameObjectWithTag("LimitRight").GetComponent<Collider2D>();
        _rect = Resources.Load<GameObject>("Prefabs/Rectangle");
        checkListOfRect();
        generateRectangles();
    }

    // Update is called once per frame
    void Update()
    {
        switch(_state)
        {
            case GenState.First: _FirstState(); break;
            case GenState.Init: _InitState(); break;
            case GenState.Normal: _NormalState(); break;
            case GenState.Play: _PlayState(); break;
            case GenState.End: _EndState(); break;
        }
    }

    private void checkListOfRect()
    {
        if (rectanglesInScene != null)
        {
            if (rectanglesInScene.Count > 0)
            {
                for(int i=0;i<rectanglesInScene.Count;i++)
                {
                    Rectangle rectangle = rectanglesInScene[i];
                    rectanglesInScene.Remove(rectangle);
                    Destroy(rectangle);
                }
            }
        }
    }

    private void generateRectangles()
    {
        rectanglesInScene = new List<Rectangle>();
        for (int i = 0; i < numOfRectanglesOnScene; i++)
        {
            GameObject game = Instantiate(_rect);
            Rectangle rectangle= game.GetComponent<Rectangle>();
            game.SetActive(false);
            rectanglesInScene.Push(rectangle);


        }
    }

    private void _FirstState()
    {
        Vector3 pos = _right.transform.position;
        Quaternion rot = _right.transform.rotation;
        pos.y -= 5;
        _last = rectanglesInScene.Pop();
        _last.gameObject.SetActive(true);
        _last.transform.position = pos;
        _last.transform.rotation = rot;
        _state= GenState.Init;
    }

    private void _InitState()
    {
        Transform next = _last.Next();
        Vector3 pos =next.transform.position;
        Quaternion rot =next.transform.rotation;
        //pos.x += 0.05f;
        if(pos.x < _right.transform.position.x)
        {
            _last = rectanglesInScene.Pop();
            _last.gameObject.SetActive(true);
            _last.transform.position = pos;
            _last.transform.rotation = rot;
            FillRectOfColour(_last);
        }
    }

    private void _NormalState()
    {
        _InitState();
        
    }

    private void GeneratePlayer()
    {
        if(!_playerGenerated)
        {
            GameObject player = Resources.Load<GameObject>("Prefabs/Stilt");
            Vector3 pos = new Vector3(-4, 5, 0);
            Quaternion rot = this.transform.rotation;
            Instantiate(player, pos, rot);
            _playerGenerated = true;
            
        }
    }

    private void _EndState()
    {
        throw new NotImplementedException();
    }

    private void _PlayState()
    {
        GeneratePlayer();
        Transform next = _last.Next();
        Vector3 pos = next.transform.position;
        Quaternion rot = next.transform.rotation;
        pos.x += 0.05f;
        if (pos.x < _right.transform.position.x)
        {
            Vector3 scale = _last.transform.localScale;
            float num = Random.Range(5,15);
            _last = rectanglesInScene.Pop();
            _last.gameObject.SetActive(true);
            _last.transform.position = pos;
            _last.transform.rotation = rot;
            FillRectOfColour(_last);
            scale.y = num;
            _last.transform.localScale = scale;
        }
    }

    private void FillRectOfColour(Rectangle rect)
    {
        SpriteRenderer renderer = rect.GetComponent<SpriteRenderer>();
        renderer.color = colours[Random.RandomRange(0, colours.Count)];
    }

    public void Add(Rectangle rectangle)
    {
        rectanglesInScene.Add(rectangle);
    }

    public GenState GetState()
    {
        return _state;
    }

    public void SetState(GenState state)
    {
        _state = state;
    }

    public void AddPoints()
    {
        Points += 100;
    }
}
