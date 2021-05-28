using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface GameState
{
    public enum State { START, WIN, LOSE, TIE};
}
public class GameManager : MonoBehaviour
{
    private Element qElement;
    private Element aElement;
    public static GameState.State gameState;
    private ElementManager myElementManager;
    private UIManager myUIManager;
    private int score;
    
    void Start()
    {
        myElementManager = GetComponent<ElementManager>();
        myUIManager = GetComponent<UIManager>();
        myElementManager.InstantiateElements();
        score = 00;
        myUIManager.Initialize();
        gameState = GameState.State.START;
        CheckState(gameState);
    }


    private void SetQuestion() 
    {
        int index = Random.Range(0, myElementManager.elementList.Length);
        qElement = myElementManager.elementList[index];
        Debug.Log(qElement.myType);
        myUIManager.SetQuestionSprite(index);
    }

    public void SetAnswer(int index)
    {
        aElement = myElementManager.elementList[index-1];
        CompareElements(aElement, qElement);
    }

    private void CompareElements(Element playerElement, Element gameElement)
    {
        if (gameElement.myType == playerElement.myType)
        {
            gameState = GameState.State.TIE;
        }
        else if (System.Array.Find(playerElement.winTo, element => element == gameElement.myType) != ElementType.Type.DEFAULT)
        {
            gameState = GameState.State.WIN;
        }
        else if (System.Array.Find(playerElement.loseTo, element => element == gameElement.myType) != ElementType.Type.DEFAULT)
        {
            gameState = GameState.State.LOSE;
        }

        CheckState(gameState);
    }


    public void CheckState(GameState.State currentState)
    {
       switch(currentState)
        {
            case GameState.State.START:
                SetQuestion();
                break;

            case GameState.State.WIN:
                SetQuestion();
                AddScore(10);
                break;

            case GameState.State.LOSE:
                if(score>PlayerPrefs.GetInt("highScore"))
                {
                    PlayerPrefs.SetInt("highScore", score);
                }
                myUIManager.GoHome(true);
                break;

            case GameState.State.TIE:
                SetQuestion();
                break;

            default:
                myUIManager.GoHome(true);
                break;

        }
    }

    private void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        myUIManager.SetScore(scoreToAdd);
        
    }
}
