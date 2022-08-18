using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiController : Singleton<UiController>
{
    // No Ui
    [SerializeField] GameObject _bird;
    [SerializeField] GameObject _columns;

    // PanelGetReady
    [SerializeField] Text _markTxt;
    [SerializeField] Button _backGroundBt;

    [SerializeField] GameObject _gameOverPanel;
    [SerializeField] GameObject _allButton;
    [SerializeField] Button _playGameBt;

    [SerializeField] GameObject _readyPanel;

    private void Awake()
    {
        base.Awake();
        _markTxt.text = 0.ToString();

        _playGameBt.onClick.AddListener(PlayGame);
        _backGroundBt.onClick.AddListener(StartGame);
    }

    public void SetMark()
    {
        _markTxt.text = GameManager._instance.GetMark().ToString();
    }

    public void PlayGame()
    {
   
        GameManager._instance.StartGame();
    }
    public void GameOver()
    {
        _readyPanel.SetActive(false);
        _allButton.SetActive(true);
        _gameOverPanel.SetActive(true);
        _bird.SetActive(false);

    }
    public void StartGame()
    {
        _readyPanel.SetActive(false);
        _columns.SetActive(true);
        _markTxt.gameObject.SetActive(true);
        GameManager._instance.SetMark();
        BirdController._instance._isPlayGame = true;
        BirdController._instance.ChangeBodyTypeToDynamic();
    }    
}
