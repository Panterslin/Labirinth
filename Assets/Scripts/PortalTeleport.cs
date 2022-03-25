using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script should be signed to ColliderPlane

public class PortalTeleport : MonoBehaviour
{
    public Transform player;
    public Transform receiver;
    bool playerIsOverlapping = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerIsOverlapping = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerIsOverlapping = false;
        }
    }
    private void FixedUpdate()
    {
        Teleportation();
    }

    private void Teleportation()
    {

        if(playerIsOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(portalToPlayer, transform.up); // iloczyn skalarny;
            Debug.Log($"DotProduct:{dotProduct}");
            if(dotProduct >0F)
            {
                float playerCapsuleColliderHalfOfHeight = player.GetComponent<CharacterController>().height;
                player.position = receiver.position + Vector3.up * playerCapsuleColliderHalfOfHeight;
            }
           
        }
    }
}
