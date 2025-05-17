using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedMove;
    public Rigidbody2D rigid;

    private StateMachine stateMachine;
    private IdleState idleState;
    private RunState runState;
    private AttackState attackState;

    private PlayerInputHandler inputHandler;
    private BulletSpawner bulletSpawner;
    private PlayerAnimation playerAnimation;

    void Start()
    {
        inputHandler = new PlayerInputHandler();
        bulletSpawner = new BulletSpawner(transform);
        playerAnimation = new PlayerAnimation(GetComponent<Animator>());

        rigid = GetComponent<Rigidbody2D>();

        stateMachine = GetComponent<StateMachine>();
        idleState = new IdleState(this, playerAnimation);
        runState = new RunState(this, playerAnimation);
        attackState = new AttackState(this);

        stateMachine.ChangeState(idleState);
    }

    void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        float inputX = inputHandler.GetHorizontalInput();

        if (inputHandler.IsAttackPressed())
        {
            stateMachine.ChangeState(attackState);
        }
        else if (inputX == 0)
        {
            stateMachine.ChangeState(idleState);
        }
        else
        {
            stateMachine.ChangeState(runState);
        }

        if (inputHandler.IsShootPressed())
        {
            bulletSpawner.Shoot();
        }
    }

    public float GetHorizontalInput()
    {
        return inputHandler.GetHorizontalInput();
    }
}
