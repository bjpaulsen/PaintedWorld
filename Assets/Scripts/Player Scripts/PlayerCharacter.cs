// PlayerCharacter
// The character that the player controls

using System.Collections;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using UnityEngine;

public enum Move
{
    Left = -1,
    Right = 1
}

public class PlayerCharacter : MonoBehaviour
{
    // TEMPORARY: move to scene info object
    public float rightBoundary = 10;

    // References
    private SpriteRenderer sprite;

    // Constants

    [SerializeField]
    private float walkSpeed = 1;
    public float WalkSpeed { get { return walkSpeed; } }


    public void Walk(Move direction)
    {
        
        float oldX = transform.position.x;
        float newX = oldX + WalkSpeed * (int) direction;
        if (newX <= rightBoundary)
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}