using UnityEngine;
using System;

public class PlayerMovementState : MonoBehaviour
{
    public enum MoveState
    {
        Idle,
        Run,
    }
    public static Action<MoveState> OnPlayerMoveStateChange;
    public MoveState currentMoveState { get; private set; }
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    private const string idleAnim = "Idle_0";
    private const string runAnim = "Run";

    public void SetMoveState(MoveState moveState)
    {
        if (moveState == currentMoveState) return;

        switch (moveState)
        {
            case MoveState.Idle:
                HandleIdle();
                break;
            case MoveState.Run:
                HandleRun();
                break;
            default:
                Debug.LogError($"Invalid movement state: {moveState}");
                break;
        }

        OnPlayerMoveStateChange?.Invoke( moveState );
        currentMoveState = moveState;
    }

    private void Update()
    {
        if(rb.linearVelocity.x == 0 && rb.linearVelocity.y == 0)
        {
            SetMoveState(MoveState.Idle);
        }
        else
        {
            SetMoveState(MoveState.Run);
        }
    }
    private void HandleIdle()
    {
        anim.Play(idleAnim);
    }
    private void HandleRun()
    {
        anim.Play(runAnim);
    }
}
