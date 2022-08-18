using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static SoundController;

public class UiController : Singleton<UiController>
{
    // No Ui
    [SerializeField] GameObject _bird;
    [SerializeField] GameObject _columns;
    [SerializeField] GameObject _allWall;

    // PanelGetReady
    [SerializeField] Text _markTxt;
    [SerializeField] Button _backGroundBt;

    // PanelGameOver
    [SerializeField] GameObject _gameOverPanel;
    [SerializeField] GameObject _gameOverTxt;
    [SerializeField] GameObject _medal;


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
        _markTxt.text = GameManager._instance.GetCurrentMark().ToString();
    }

    public void PlayGame()
    {
        GameManager._instance.StartGame();
    }
    public void GameOver()
    {
        SoundController._instance.OnPlayAudio(SoundType.death);
        GameManager._instance.SetMaxMark(GameManager._instance.GetCurrentMark());
        ChangeMoveSpeed();
        BirdController._instance.Die();
        StartCoroutine(SetActivePanelGameOver());
    }
    IEnumerator SetActivePanelGameOver()
    {
        yield return new WaitForSeconds(1f);

        _gameOverPanel.SetActive(true);

        _gameOverTxt.SetActive(true);
       // yield return new WaitForSeconds(0.1f);
        _gameOverTxt.GetComponent<Animator>().SetBool("Idle", true);

        _medal.SetActive(true);
        yield return new WaitForSeconds(0.65f);
        _medal.GetComponent<Animator>().SetBool("Idle", true);

        yield return new WaitForSeconds(0.5f);
        _allButton.SetActive(true);
    }
    void ChangeMoveSpeed()
    {
        _columns.GetComponent<Move>()._speed = 0f;
        _allWall.GetComponent<Move>()._speed = 0f;

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
