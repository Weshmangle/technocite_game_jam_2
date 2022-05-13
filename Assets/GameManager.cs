using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static readonly float TIME_OUT_NEXT_CARD = 5;
    public static readonly float TIME_OUT_NEXT_BOOK = 60;
    public static readonly float TIME_OUT_GAME_OVER = 5 * 60;
    public static readonly float NUMBER_CARD_START = 3;
    public bool gameOver;
    public BoardPlayer winner;

    [SerializeField] public BoardPlayer boardPlayerA;
    [SerializeField] public BoardPlayer boardPlayerB;

    public List<Card> deckA = new List<Card>();
    public List<Card> deckB = new List<Card>();
    public GameObject prefabCard;
    public float currentTime = 0f;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StarterPickCard();
    }

    void Update()
    {
        if(currentTime < TIME_OUT_GAME_OVER)
        {
            currentTime += Time.deltaTime;
        }
        else
        {
            gameOver = true;
            winner = boardPlayerA;
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

    public BoardPlayer PlayerWinner()
    {
        if(gameOver)
        {
            return winner;
        }
        else
        {
            throw new System.Exception("No winner because Game is not finish");
        }
    }
}
