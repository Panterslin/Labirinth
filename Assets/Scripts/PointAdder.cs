using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAdder : PickUp
{
    public int points = 5;
    public override void Picked() // nadpisanie metody Picked
    {
        GameManager.gameManager.AddPoints(points);
        Destroy(this.gameObject);
    }
}
