using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour, model.Observer
{
    public static GameManager Instance;
    public static float DEBUG_FACTOR = .1f;
    [SerializeField] public DatasGame datasGame;
    [SerializeField] public UBoard boardPlayerA;
    [SerializeField] public UBoard boardPlayerB;
    public CountDown globalCountDown;
    public model.Game game;
    protected bool gameIsOver;
    protected UBoard[] boards;

    private void Awake()
    {
        Instance = this;
        gameIsOver = false;
        boardPlayerB.canvasTextRelic.gameObject.SetActive(true);
        game = new model.Game();
        game.AddObserver(this);
        List<model.PrototypeCard>[] prototypeCards = new List<model.PrototypeCard>[2];
        prototypeCards[0] = ConvertPrototypeCard(boardPlayerA.starterDeck.cards);
        prototypeCards[1] = ConvertPrototypeCard(boardPlayerB.starterDeck.cards);
        game.PrepareGame(5, 5, 
            datasGame.durationSecondsGame,
            datasGame.numberCardStartGame,
            datasGame.timeSecondsNextBook, prototypeCards);
        boards = new UBoard[]{boardPlayerA, boardPlayerB};
    }

    protected List<model.PrototypeCard> ConvertPrototypeCard(UPrototypeCard[] cards)
    {
        List<model.PrototypeCard> protos = new List<model.PrototypeCard>();     
        foreach (var proto in cards)
        {
            protos.Add(new model.PrototypeCard(proto.name, "", new model.EffectNothing()));
        }

        return protos;
    }

    void Start()
    {
        game.StartGame();
        StarterPickCard();
        globalCountDown.SetTimeOut(datasGame.durationSecondsGame);
        globalCountDown.StartCoundtDown();
    }

    void Update()
    {
        if(game.IsOver() && !gameIsOver)
        {
            gameIsOver = true;
            if(game.Winner() == game.GetBoard(true))
            {
                UIManager.Instance.ShowWinnerPlayerA();
                Invoke(nameof(ReloadGame), 5f);
            }
            else
            {
                UIManager.Instance.ShowWinnerPlayerB();
                Invoke(nameof(ReloadGame), 5f);
            }
        }
        else
        {
            game.IncrementTime(Time.deltaTime);
        }
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StarterPickCard()
    {
        for (var i = 0; i < datasGame.numberCardStartGame; i++)
        {
            foreach (var board in game.Boards)
            {
                game.PickCard(board);
            }
        }
    }

    public UBoard GetBoardOpponent(UCard card)
    {
        if(card.Board.Faction == boardPlayerA.Faction)
        {
            return boardPlayerB;
        }
        else
        {
            return boardPlayerA;
        }
    }

    public void AddParticlesToCard(UCard card)
    {
        Vector3 position = card.transform.position;
        position.y = 1f;
        Instantiate(PrefabsManager.Instance.particlesPrefab, position, card.transform.rotation, card.transform);
        card.transform.localScale = Vector3.zero;
    }

    public void UpdateBoardGame(object args)
    {
//        Debug.Log(args);
    }
}
