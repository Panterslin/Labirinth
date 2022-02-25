using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] //pozwala na odwo³ania publiczne do skryptu
    float speed = 12f;
    CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();//metoda pobieraj¹ca z unity komponent chracter controller
    }
    void Update()
    {
        PlayerMove();
    }
    void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal");//pobieranie w zmienn¹ oœ pionow¹ a=-1,d=1
        float z = Input.GetAxis("Vertical");//pobieranie w zmienn¹ oœ poziom¹ w=1,s=-1

        //Vector3 move = Vector3.right * x + Vector3.forward * z;//bez obrotu gracza
        Vector3 move = transform.right * x + transform.forward * z;//z obrotem
        characterController.Move(move * speed * Time.deltaTime);
    }
}
