using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAdder : PickUp
{
    public int time = 5;
    public override void Picked()
    {
        GameManager.gameManager.AddTime(time);
        Destroy(this.gameObject);
    }
}
