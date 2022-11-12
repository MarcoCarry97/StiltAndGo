using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private Button _button;


    // Start is called before the first frame update
    void Start()
    {
        _button=this.GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        RectGenerator gen = GameObject.FindGameObjectWithTag("Generator")
            .GetComponent<RectGenerator>();
        gen.SetState(RectGenerator.GenState.Play);
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
