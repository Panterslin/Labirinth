using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : PickUp
{
    public bool addTime;// true dodaje, false odejmuje
    public int time = 5;

    public override void Picked()
    {
        if (addTime == true)
        {
            GameManager.gameManager.AddTime(time);
            Destroy(this.gameObject);
        }
        else
        {
            GameManager.gameManager.SubtractTime(time);
            Destroy(this.gameObject);
        }
    }
}
