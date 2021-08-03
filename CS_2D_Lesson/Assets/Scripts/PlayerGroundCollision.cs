using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCollision : MonoBehaviour
{

    [SerializeField] PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerController.isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerController.isGrounded = false;
    }
}
