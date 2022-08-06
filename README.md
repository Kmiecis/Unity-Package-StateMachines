# Common Behaviour Trees

## Description

Both code-only and Animator, simple and lightweight state machines implementation.

## Examples

<details>
<summary>Code-only</summary>
<p>

### Code-only state machine example
#### The logic is implemented only through code and executed on its side

```cs
public class Player : MonoBehaviour
{
    private SM_IStateMachine _stateMachine;

    public bool IsGrounded
    {
        get => // Returns adequatelly
    }

    public bool HasJumpInput
    {
        get => // Returns adequatelly
    }

    public void Jump()
    {
        // Perform jump action
        // Run jump animation
    }

    public void Idle()
    {
        // Run idle animation
    }

    private void Awake()
    {
        _stateMachine = new SM_StateMachine()
            .WithState(new IdleState(this))
            .WithState(new JumpState(this));
    }

    private void Update()
    {
        _stateMachine.Execute();
    }
}

public class IdleState : SM_AState<Player>
{
    public IdleState(Player context) :
        base(context)
    {
        WithTransition<JumpState>(CanJump);
    }

    private bool CanJump()
    {
        return _context.HasJumpInput && _context.IsGrounded;
    }

    protected override void OnStart()
    {
        base.OnStart();

        _context.Idle();
    }
}

public class JumpState : SM_AState<Player>
{
    public JumpState(Player context) :
        base(context)
    {
        WithTransition<IdleState>(IsIdle);
    }

    private bool IsIdle()
    {
        return _context.IsGrounded;
    }

    protected override void OnStart()
    {
        base.OnStart();

        _context.Jump();
    }
}
```

</p>
</details>

<details>
<summary>Animator</summary>
<p>

### Animator state machine example
#### The logic is implemented both in code and in Unity Animator window, which mostly takes care of transitions between states

```cs
public class Player : MonoBehaviour
{
    public Animator animator;

    public bool IsGrounded
    {
        get => // Returns adequatelly
    }

    public bool HasJumpInput
    {
        get => // Returns adequatelly
    }

    public void Jump()
    {
        // Perform jump action
    }

    private void Awake()
    {
        var behaviours = animator.GetBehaviours<APlayerStateBehaviour>();
        foreach (var behaviour in behaviours)
        {
            behaviour.Setup(animator, this);
            behaviour.Enable();
        }
    }
}

public abstract class APlayerStateBehaviour : SM_AAnimatorBehaviour<Player>
{
    private static readonly int kIsGrounded = Animator.StringToHash("IsGrounded");
    private static readonly int kHasJumpInput = Animator.StringToHash("HasJumpInput");

    protected override void OnEnter()
    {
        base.OnEnter();

        UpdateParameters();
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        UpdateParameters();
    }

    private void UpdateParameters()
    {
        _animator.SetBool(kIsGrounded, _context.IsGrounded);
        _animator.SetBool(kHasJumpInput, _context.HasJumpInput);
    }
}

public class PlayerIdleStateBehaviour : APlayerStateBehaviour
{
}

public class PlayerJumpStateBehaviour : APlayerStateBehaviour
{
    protected override void OnEnter()
    {
        base.OnEnter();

        _context.Jump();
    }
}
```

</p>
</details>
