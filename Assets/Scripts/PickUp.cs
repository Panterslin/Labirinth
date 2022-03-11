using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public virtual void Picked()
    {
        Debug.Log("Picked");
        Destroy(this.gameObject); // usuwa ten obiekt z gry
    }
   
    void Start()
    {
        
    }

    
    private void Update()
    {
        Rotation();
    }
    private void Rotation()
    {

        transform.Rotate(new Vector3(0f, 0f, 2f));// tworzy vectory 3d , wed³ug których obraca obiekt
    }
}
