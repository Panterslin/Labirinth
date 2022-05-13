using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : PickUp
{
    public KeyColor keyColor;
    public override void Picked()
    {
        GameManager.gameManager.AddKey(keyColor);
        Destroy(this.gameObject);
    }
    override protected void Rotation()
    {
        transform.Rotate(new Vector3(0f, 0f, 1f));
    }
}
