using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public int _mark = 0;

    void Start()
    {
        Application.targetFrameRate = 60;
        DontDestroyOnLoad(this);
    }
    private void Awake()
    {
        base.Awake();
    }
   public void StartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void CountMark()
    {
        _mark += 1;
    }

    public void SetMark()
    {
        _mark = 0;
    }
    public int GetMark()
    {
        return _mark;
    }    

}
