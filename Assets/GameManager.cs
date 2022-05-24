using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static readonly float DEBUG_FACTOR = .1f;
    public static readonly float TIME_OUT_NEXT_CARD = 20 * DEBUG_FACTOR;
    public static readonly float TIME_OUT_NEXT_BOOK = 60 * DEBUG_FACTOR;
    public static readonly float TIME_OUT_GAME_OVER = 5 * 60 * DEBUG_FACTOR;
    public static readonly float NUMBER_CARD_START = 3;
    public static readonly float RELIC_COUNT_VICTORY = 10;
    public static bool GAME_IS_OVER;

    [SerializeField] public BoardPlayer boardPlayerA;
    [SerializeField] public BoardPlayer boardPlayerB;
    public BoardPlayer winner;

    public List<Card> deckA = new List<Card>();
    public List<Card> deckB = new List<Card>();
    public GameObject prefabCard;
    public float currentTime = 0f;
    public CountDown globalCountDown;
    public GameObject panelGameOver;
    public Text textWin;
    public GameObject particlesPrefab;

    private void Awake()
    {
        Instance = this;
        boardPlayerB.canvasTextRelic.gameObject.SetActive(true);
    }

    void Start()
    {
        foreach (var card in boardPlayerA.deck.cards)
        {
            card.currentBackcard = card.backcardA;
        }

        foreach (var card in boardPlayerB.deck.cards)
        {
            card.currentBackcard = card.backcardB;
        }

        Card[] cards = boardPlayerB.deck.GetComponentsInChildren<Card>();

        foreach (var card in cards)
        {
            card.currentBackcard = card.backcardB;
        }

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
            winner = boardPlayerA;
            textWin.text = $"{winner.Faction} / 10";
            panelGameOver.gameObject.SetActive(true);
            Invoke(nameof(ReloadGame), 5f);
        }
        
        if(boardPlayerB.countRelic == RELIC_COUNT_VICTORY)
        {
            GAME_IS_OVER = true;
            winner = boardPlayerB;
            textWin.text = $"{winner.Faction} / 10";
            panelGameOver.gameObject.SetActive(true);
            Invoke(nameof(ReloadGame), 5f);
        }
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
            return winner;
        }
        else
        {
            throw new System.Exception("No winner because Game is not finish");
        }
    }

    public void AddParticlesToCard(Card card)
    {
        Vector3 position = card.transform.position;
        position.y = 1f;
        Instantiate(particlesPrefab, position, card.transform.rotation, card.transform);
        card.transform.localScale = Vector3.zero;
    }
}
