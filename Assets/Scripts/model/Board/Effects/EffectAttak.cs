namespace model
{ 
    class EffectAttak : Effect
    {
        public bool alreadyAttak = false;
        public override bool IsComplete()
        {
            return alreadyAttak;
        }

        public override void Progress(float step, Card card, object? args = null)
        {
            if(args is model.Game)
            {
                model.Game game = args as model.Game;
                
                if(game is not null)
                {
                    game.GetOpponentBoard(card.emplacement.board).GetGround().RemoveCard(card.emplacement);
                }
            }
        }
    }   
}