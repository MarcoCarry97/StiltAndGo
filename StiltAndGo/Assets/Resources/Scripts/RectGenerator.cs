using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Services.Core;
using UnityEngine;
using Random = UnityEngine.Random;

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

    private GenState _state;
    private Collider2D _left;
    private Collider2D _right;

    private GameObject _rect;
    private Rectangle _last;

    private bool _playerGenerated;

    // Start is called before the first frame update
    void Start()
    {
        _playerGenerated = false;
        _state=GenState.First;
        _left = GameObject.FindGameObjectWithTag("LimitLeft").GetComponent<Collider2D>();
        _right = GameObject.FindGameObjectWithTag("LimitRight").GetComponent<Collider2D>();
        _rect = Resources.Load<GameObject>("Prefabs/Rectangle");
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

    private void _FirstState()
    {
        Vector3 pos = _right.transform.position;
        Quaternion rot = _right.transform.rotation;
        pos.y -= 5;
        _last = Instantiate<GameObject>(_rect, pos, rot).GetComponent<Rectangle>();
        _state= GenState.Init;
    }

    private void _InitState()
    {
        Transform next = _last.Next();
        Vector3 pos =next.transform.position;
        Quaternion rot =next.transform.rotation;
        pos.x += 0.05f;
        if (pos.x <= _right.transform.position.x)
        {
            _last = Instantiate<GameObject>(_rect, pos, rot).GetComponent<Rectangle>();
        }
    }

    private void _NormalState()
    {
        _InitState();
    }

    private void _GeneratePlayer()
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
        Transform next = _last.Next();
        Vector3 pos = next.transform.position;
        Quaternion rot = next.transform.rotation;
        pos.x += 0.05f;
        if (pos.x <= _right.transform.position.x)
        {
            _last = Instantiate<GameObject>(_rect, pos, rot).GetComponent<Rectangle>();
            float size = Random.Range(0, _rect.transform.localScale.y*1.5f);
            Vector3 locScale = _last.transform.localScale;
            locScale.y += size;
            _last.transform.localScale = locScale;
        }
    }

    public GenState GetState()
    {
        return _state;
    }

    public void SetState(GenState state)
    {
        _state = state;
    }
}
