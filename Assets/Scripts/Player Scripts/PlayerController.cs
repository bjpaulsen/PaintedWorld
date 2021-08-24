// PlayerController
// Enables user interaction with the game and character

using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerCharacter player;

    private void Update() {    
        player.Walk(MoveDirection());
    }

    private Move MoveDirection()
    {
        return (Move) Input.GetAxis("Horizontal");
    }
}