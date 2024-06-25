using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using ToolBox.Core;
using ToolBox.GUI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanel : Panel
{

    private Button button;

    private TMP_Text pointsView;

    private GameController state;

    // Start is called before the first frame update
    void Start()
    {
        button = transform.GetChild(2).gameObject.GetComponent<Button>();
        button.onClick.AddListener(OnTryAgain);
        state = GameController.Instance;
        pointsView = this.transform.GetChild(1).GetComponent<TMP_Text>();
    }

    private void OnTryAgain()
    {
        GameController.Instance.Clear();
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
        RectGenerator rectGen=GameObject.FindObjectOfType<RectGenerator>();
        pointsView.text = String.Format("Points: {0}", rectGen.Points);
    }
}