using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class View : MonoBehaviour {
    private RectTransform logoName;
    private RectTransform menuUI;
    private RectTransform GameUI;
    private GameObject RestartButton;
    private Text score;
    private Text highscore;
    private GameObject GameOverUI;
    private Text GameoverText;
    private GameObject SettingUI;
    private Ctrl ctrl;
    private GameObject mute;
    private GameObject RanUI;
    private Text R_score;
    private Text R_highscore;
    private Text R_numbersscore;

    // Use this for initialization
    void Awake() {
        logoName = transform.Find("Canvas/Logoname") as RectTransform;
        menuUI = transform.Find("Canvas/MenuUI") as RectTransform;
        GameUI = transform.Find("Canvas/GameUI") as RectTransform;
        RestartButton = transform.Find("Canvas/MenuUI/RestartButton").gameObject;
        score = transform.Find("Canvas/GameUI/ScoreText").GetComponent<Text>();
        highscore = transform.Find("Canvas/GameUI/MaxScoreText").GetComponent<Text>();
        GameOverUI = transform.Find("Canvas/GameOverUI").gameObject;
        GameoverText = transform.Find("Canvas/GameOverUI/CurrentScore").GetComponent<Text>();
        SettingUI = transform.Find("Canvas/Setting").gameObject;
        ctrl = GameObject.Find("Ctrl").GetComponent<Ctrl>();
        mute = transform.Find("Canvas/Setting/Image/AudioButton/Image/Mute").gameObject;
        RanUI = transform.Find("Canvas/RankUI").gameObject;
        R_score = transform.Find("Canvas/RankUI/CurrentScore").GetComponent<Text>();
        R_highscore= transform.Find("Canvas/RankUI/MaxScore").GetComponent<Text>();
        R_numbersscore = transform.Find("Canvas/RankUI/NumbersGame").GetComponent<Text>();
    }

    public void ShowMenu()
    {
        logoName.gameObject.SetActive(true);
        logoName.DOAnchorPosY(-70, 0.5f);
        menuUI.gameObject.SetActive(true);
        menuUI.DOAnchorPosY(52, 1f);

    }
    public void HideMenu()
    {
        logoName.DOAnchorPosY(70, 0.5f).OnComplete(delegate { logoName.gameObject.SetActive(false); });
        menuUI.DOAnchorPosY(-52, 1f).OnComplete(delegate { menuUI.gameObject.SetActive(false); });
    }
    public void ShowGameUI(int score = 0, int highscore = 0)
    {
        GameUI.gameObject.SetActive(true);
        GameUI.DOAnchorPosY(-71, 0.5f);
        this.score.text = score.ToString();
        this.highscore.text = highscore.ToString();

    }
    public void HideGameUI()
    {
        GameUI.DOAnchorPosY(-71, 0.5f).OnComplete(delegate { GameUI.gameObject.SetActive(false); });
    }
    public void ShowRestartButon()
    {
        RestartButton.SetActive(true);
    }
    public void UpdataGameUI(int score,int highscore){

        this.score.text = score.ToString();
        this.highscore.text = highscore.ToString();

    }
    public void ShowGameOverUI(int socre = 0)
    {
        GameOverUI.SetActive(true);
        GameoverText.text = socre.ToString();
    }
    public void OnHomeButtonClick()
    {
        ctrl.AudioManager.PlayCursor();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void HideGameOverUI()
    {
        GameOverUI.SetActive(false);
    }
    public void OnSettingButtonClick()
    {
        ctrl.AudioManager.PlayCursor();
        ShowSettingUI();

    }
    public void ShowSettingUI()
    {
        
        SettingUI.SetActive(true);
    }
    public void SetMuteActive(bool isActive)
    {
        mute.gameObject.SetActive(isActive);
    }
    public void OnSettingUIClick()
    {
        SettingUI.SetActive(false);
    }
    public void OnHideRankUIClick()
    {
        RanUI.SetActive(false);
    }
    public void OnRankUIClick()
    {
        ctrl.AudioManager.PlayCursor();
        ShowRankUI(ctrl.model.Socre,ctrl.model.HighScore,ctrl.model.NumbersGame);
    }
    public void ShowRankUI(int socre,int highsocre,int numbersGame)
    {
        RanUI.SetActive(true);
        R_score.text = score.ToString();
        R_highscore.text = highscore.ToString();
        R_numbersscore.text = numbersGame.ToString();
    }
}
