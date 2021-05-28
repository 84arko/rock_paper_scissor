using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    private GameManager myGameManger;

    [SerializeField]
    private Sprite[] elementSprites;
    [SerializeField]
    private Button[] elementButtons;
    [SerializeField]
    private GameObject qSprite;
    [SerializeField]
    private GameObject aSprite;

    [SerializeField]
    private Slider timerBar;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text highScoreText;
    private bool startTimer;
    private float gameTime;



    // Start is called before the first frame update
    void Start()
    {
       if(highScoreText!=null)
        {
            highScoreText.text = PlayerPrefs.GetInt("highScore").ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameTimer();
    }


    public void Initialize()
    {
        myGameManger = GetComponent<GameManager>();
        startTimer = false;
        gameTime = 1f;
        timerBar.value = gameTime;
    }
    public void ElementButton(int index)
    {
        startTimer = false;
        gameTime = 1;
        myGameManger.SetAnswer(index);
        aSprite.GetComponent<SpriteRenderer>().sprite = elementSprites[index-1];
        aSprite.SetActive(true);

    }

    public void SetQuestionSprite(int index)
    {
        qSprite.GetComponent<SpriteRenderer>().sprite = elementSprites[index];
        qSprite.SetActive(true);
        
        
        startTimer = true;
    }

    private void GameTimer()
    {

        if (startTimer)
        {
            gameTime -= Time.deltaTime ;
            timerBar.value = gameTime;
            if(gameTime<=0)
            { 
                GameManager.gameState = GameState.State.LOSE;
                myGameManger.CheckState(GameManager.gameState);
            }
        }
    }

    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }


    public void GoHome(bool value)
    {
        if(value)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

}
