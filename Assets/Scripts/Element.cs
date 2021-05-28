using UnityEngine;


public interface ElementType
{
    public enum Type {DEFAULT, ROCK, PAPER, SCISSOR, LIZARD, SPOCK};
    public enum GameState { START, WIN, LOSE, TIE};
}
public class Element 
{
    public ElementType.Type myType { get; set; }
    public ElementType.Type[] winTo { get; set; }
    public ElementType.Type[] loseTo { get; set; }


    public void SetElement(ElementType.Type thisType, ElementType.Type[] thisWinTo, ElementType.Type[] thisLoseTo)
    {
        myType = thisType;
        winTo = thisWinTo;
        loseTo = thisLoseTo;
        
    }
}
