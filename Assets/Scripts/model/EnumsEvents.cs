namespace model
{
    public enum TypeAction
    {
        UPDATE_GAME,
        GAME_READY,
        ADD_CARD_HAND,
        REMOVE_CARD_HAND,
        ADD_CARD_GROUND,
        REMOVE_CARD_GROUND,
        NEXT_EFFECT,
        PROGRESS_EFFECT,
    }

    public enum TypeError
    {
        HAND_FULL,
        CARD_NOT_HAND
    }
}