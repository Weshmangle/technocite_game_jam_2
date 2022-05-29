class EffectAttak : Effect
{
    public bool alreadyAttak = false;
    public override bool IsComplete()
    {
        return alreadyAttak;
    }

    public override void Progress(float step, Card card, Object? args = null)
    {
        if(args is CardGame.Game)
        {
            CardGame.Game? game = args as CardGame.Game;
            
            if(game is not null)
            {
                game.GetOpponentBoard(card.emplacement.board).GetGround().RemoveCard(card.emplacement);
            }
        }
    }
}