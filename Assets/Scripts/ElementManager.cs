using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementManager : MonoBehaviour
{
    public Element[] elementList { get; set; } = new Element[5];
  

    public void InstantiateElements()
    {
        for(int i=0; i<elementList.Length;i++)
        {
            elementList[i] = new Element();
        }

        elementList[0].SetElement(ElementType.Type.ROCK, new ElementType.Type[] { ElementType.Type.SCISSOR, ElementType.Type.LIZARD }, new ElementType.Type[] { ElementType.Type.PAPER, ElementType.Type.SPOCK });
        elementList[1].SetElement(ElementType.Type.PAPER, new ElementType.Type[] { ElementType.Type.ROCK, ElementType.Type.SPOCK }, new ElementType.Type[] { ElementType.Type.LIZARD, ElementType.Type.SCISSOR });
        elementList[2].SetElement(ElementType.Type.SCISSOR, new ElementType.Type[] { ElementType.Type.PAPER, ElementType.Type.LIZARD }, new ElementType.Type[] { ElementType.Type.ROCK, ElementType.Type.SPOCK });
        elementList[3].SetElement(ElementType.Type.LIZARD, new ElementType.Type[] { ElementType.Type.PAPER, ElementType.Type.SPOCK }, new ElementType.Type[] { ElementType.Type.ROCK, ElementType.Type.SCISSOR });
        elementList[4].SetElement(ElementType.Type.SPOCK, new ElementType.Type[] { ElementType.Type.ROCK, ElementType.Type.SCISSOR }, new ElementType.Type[] { ElementType.Type.PAPER, ElementType.Type.LIZARD });
    }

   
}
