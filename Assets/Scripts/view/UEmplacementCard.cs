using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UEmplacementCard : MonoBehaviour
{
    public UBoard board;
    public UCard card;
    public int index;
    public bool ground;
    public Collider colliderGround;
    public Collider colliderHand;

    private void Update()
    {
        colliderGround.enabled = ground;
        colliderHand.enabled = !ground;
    }
}
