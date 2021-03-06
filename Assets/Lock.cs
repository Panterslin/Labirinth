using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    bool iCanOpen = false;
    public Door door;
    public KeyColor myColor;
    bool locked = false;
    Animator keyAnimator;
    private void Start()
    {
        keyAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && iCanOpen && !locked) // get button down jest do myszy // po podej?ciu do drzwi i wci?ni?ciu E zadzia?a zawarto?? if
        { // !bool - false w operatorach logicznych 
            keyAnimator.SetBool("useKey", CheckTheKey());
        }
    }
    public void UseKey()
    {
        door.CloseOpen();
    }
    public bool CheckTheKey()
    {
        if(GameManager.gameManager.redKey >0 && myColor == KeyColor.Red)
        {
            GameManager.gameManager.redKey--;
            locked = true;
            return true;
        }
        else if (GameManager.gameManager.greenKey > 0 && myColor == KeyColor.Green)
        {
            GameManager.gameManager.greenKey--;
            locked = true;
            return true;
        }
        else if (GameManager.gameManager.goldKey > 0 && myColor == KeyColor.Gold)
        {
            GameManager.gameManager.goldKey--;
            locked = true;
            return true;
        }
        else
        {
            Debug.Log("No Key");
            return false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        { iCanOpen = true;
            Debug.Log("You can use the lock");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            iCanOpen = false;
            Debug.Log("Cannot use the lock");
        }
    }
}
