using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UHand : MonoBehaviour, model.Observer
{
    public UEmplacementCard[] emplacements;
    public List<UCard> cardsAnimated = new List<UCard>();
    protected model.Hand hand;

    void Update()
    {
        foreach (var emplacement in emplacements)
        {
            UCard card = emplacement.card;
            if(cardsAnimated.Contains(card))
            {
                Vector3 position = card.empplacement.transform.position - card.transform.position;
                float angle = Quaternion.Angle(card.empplacement.transform.rotation, card.transform.rotation);
                
                if(Mathf.Approximately(0.0f, angle))
                {
                    card.transform.rotation = Quaternion.identity;
                    cardsAnimated.Remove(card);
                    card.transform.position = emplacement.transform.position;
                }
                else
                {
                    card.transform.position += position * Time.deltaTime * 1f;
                    card.transform.Rotate(new Vector3(0, 0, angle) * Time.deltaTime);
                }
            }            
        }
    }

    public void SetHand(model.Hand hand)
    {
        this.hand = hand;
        hand.AddObserver(this);
    }

    public void AppendCard(UCard card)
    {
        foreach (var emplacement in emplacements)
        {
            if(emplacement.card == null)
            {
                card.transform.parent = emplacement.transform;
                emplacement.card = card;
                card.empplacement = emplacement;
                cardsAnimated.Add(card);
                return;
            }
        }
    }

    public void Discard(UCard card)
    {
        hand.RemoveCard(card.card);
    }

    public void UpdateSuccess(object args)
    {
        Debug.LogWarning(args);
    }

    public void UpdateError(object args)
    {
        Debug.LogError(args);
    }
}
