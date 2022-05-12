using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static readonly float TIME_OUT_NEXT_CARD = 5;
    public static readonly float TIME_OUT_GAME_OVER = 5 * 60;
    public static bool GAME_IS_OVER;

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
        FillDeck();
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

    public void FillDeck()
    {
    }

    public int PlayerWinner()
    {
        if(GAME_IS_OVER)
        {
            return 0;
            //return player;
        }
        else
        {
            throw new System.Exception("No winner because Game is not finish");
        }
    }
}
