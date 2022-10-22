using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanel : Panel
{

    private Button button;

    private TMP_Text pointsView;

    private GameState state;

    // Start is called before the first frame update
    void Start()
    {
        button = transform.GetChild(2).gameObject.GetComponent<Button>();
        button.onClick.AddListener(OnTryAgain);
        state = GameState.Instance;
        pointsView = this.transform.GetChild(1).GetChild(1).GetComponent<TMP_Text>();
    }

    private void OnTryAgain()
    {
        GameState.Instance.Reload();
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
        pointsView.text = String.Format("{0}", state.Points);
    }
}