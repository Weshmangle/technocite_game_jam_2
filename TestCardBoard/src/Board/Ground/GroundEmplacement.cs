public class GroundEmplacement
{
    public int index; 
    public Card card;
    public Board board;

    public GroundEmplacement(int index, Board board)
    {
        this.board = board;
        this.index = index;
    }
}