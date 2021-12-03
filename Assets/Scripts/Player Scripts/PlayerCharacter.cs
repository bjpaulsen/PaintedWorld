// PlayerCharacter
// The character that the player controls

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Move
{
    Left = -1,
    Nowhere = 0,
    Right = 1
}

public class PlayerCharacter : MonoBehaviour
{
    // TEMPORARY: move to scene info object
    [Header("TEMPORARY")]
    public float rightBoundary = 10;
    public float leftBoundary = -10;

    [Header("References")]
    [SerializeField] Animator animator;
    private RecordPlayer recordPlayer;

    [Header("Constants")]
    [SerializeField]
    private float walkSpeed = 1;
    public float WalkSpeed { get { return walkSpeed; } }

    // Sounds
    private FMOD.Studio.EventInstance door;

    private void Awake()
    {
        //door = FMODUnity.RuntimeManager.CreateInstance("event:/LetterSong");
    }

    private void Start()
    {
        recordPlayer = (RecordPlayer) Object.FindObjectOfType(typeof(RecordPlayer));
    }

    public void Walk(Move direction)
    {
        if (direction == Move.Nowhere)
        {
            Stop();
            return;
        }

        Flip(direction);

        AnimateWalk(true);
        
        MoveHorizontal(direction, WalkSpeed);
    }

    public void Stop()
    {
        AnimateWalk(false);
    }

    private void MoveHorizontal(Move direction, float speed)
    {
        float oldX = transform.position.x;
        float newX = oldX + speed * (int) direction;
        if (newX < rightBoundary && newX > leftBoundary)
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        else // temp, should call some scene function
            ExitCabin();
    }

    private void Flip(Move direction)
    {
        float rotation = direction == Move.Left ? -180 : 0;
        transform.rotation = Quaternion.Euler(0, rotation, 0);
    }

    private void AnimateWalk(bool animate)
    {
        if (animator != null) // ignore animation during unit test
            animator.SetBool("Walking", animate);
    }

    private void ExitCabin()
    {
        recordPlayer.Muffle(1);
        SceneManager.LoadScene("OutsideCabinScene");
    }

    private void EnterCabin()
    {
        if (recordPlayer != null)
            recordPlayer.Muffle(0);
        SceneManager.LoadScene("CabinScene");
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name == "cabin")
            EnterCabin();
    }
}