using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static readonly float DEBUG_FACTOR = .1f;
    public static readonly float TIME_OUT_NEXT_CARD = 20 * DEBUG_FACTOR;
    public static readonly float TIME_OUT_NEXT_BOOK = 60 * DEBUG_FACTOR;
    public static readonly float TIME_OUT_GAME_OVER = 5 * 60 * DEBUG_FACTOR;
    public static readonly float NUMBER_CARD_START = 3;
    public static bool GAME_IS_OVER;

    [SerializeField] public BoardPlayer boardPlayerA;
    [SerializeField] public BoardPlayer boardPlayerB;

    public List<Card> deckA = new List<Card>();
    public List<Card> deckB = new List<Card>();
    public GameObject prefabCard;
    public float currentTime = 0f;
    public CountDown globalCountDown;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StarterPickCard();
        globalCountDown.SetTimeOut(TIME_OUT_GAME_OVER);
        globalCountDown.StartCoundtDown();
    }

    void Update()
    {
        if(currentTime < TIME_OUT_GAME_OVER)
        {
            currentTime += Time.deltaTime;
        }
        else
        {
            GAME_IS_OVER = true;
        }
    }

    public void StarterPickCard()
    {
        for (var i = 0; i < NUMBER_CARD_START; i++)
        {
            boardPlayerA.PickCard();
            boardPlayerB.PickCard();
        }
    }

    public BoardPlayer GetBoardOpponent(Card card)
    {
        if(card.boardPlayer.Faction == boardPlayerA.Faction)
        {
            return boardPlayerB;
        }
        else
        {
            return boardPlayerA;
        }
    }

    public BoardPlayer PlayerWinner() 
    {
        if(GAME_IS_OVER)
        {
            return boardPlayerA;
        }
        else
        {
            throw new System.Exception("No winner because Game is not finish");
        }
    }
}
