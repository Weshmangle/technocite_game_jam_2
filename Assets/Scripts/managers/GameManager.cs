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

    private void Awake()
    {
        Instance = this;
        gameIsOver = false;
        boardPlayerB.canvasTextRelic.gameObject.SetActive(true);
        game = new model.Game();
        game.AddObserver(this);
        
        List<model.PrototypeCard>[] prototypeCards = UPrototypeCard.ToListPrototypeModel(boardPlayerA.starterDeck.cards, boardPlayerB.starterDeck.cards);

        game.PrepareGame(5, 5, 
            datasGame.durationSecondsGame,
            datasGame.numberCardStartGame,
            datasGame.timeSecondsNextBook, prototypeCards);
    }

    void Start()
    {
        boardPlayerA.Init(game.Board(0));
        boardPlayerB.Init(game.Board(1));
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
                //game.PickCard(board);
            }
            boardPlayerA.PickCard();
            boardPlayerB.PickCard();
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
        Debug.Log(args);
    }

    public UBoard[] boards
    {
        get {return new UBoard[]{boardPlayerA, boardPlayerB};}
    }
}
