using UnityEngine;
using DG.Tweening;
using System.Collections;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private GameManager _gameManager;
    private Animator _animator;

    [Header("Movement ")]
    [SerializeField] private float currentSpeed = 10f;
    [SerializeField] private float _shiftDistance = 7.5f;
    [SerializeField] private float _shiftDuration = 7.5f;

    [Header("Jump ")]
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private float _jumpCooldown = 0.1f;
    [SerializeField] private float _gravityScaler = 2.5f;

    [Header("Ground Check")]
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float groundCheckDistance = 0.1f;
    [SerializeField] private float groundCheckRadius = 0.5f;
    [SerializeField] private Transform checkPoint;

    [Header("Mobile Input")]
    [SerializeField] private float swipeThreshold = 80f;

    [Header("Speed Increase ")]
    [SerializeField] private float startingSpeed = 20f;
    [SerializeField] private float speedIncreaseAmount = 2f;
    [SerializeField] private float speedIncreaseInterval = 5f;

    private bool canJump = true;
    private bool isGrounded;
    private int lane = 2;
    private bool canShift = true;

    private Vector2 touchStartPos;
    private Vector2 touchEndPos;
    private float currentTime = 0;

    Quaternion startRotation = Quaternion.identity;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _gameManager = FindObjectOfType<GameManager>();
        _animator = transform.GetChild(0).GetComponent<Animator>();
        currentSpeed = startingSpeed;
        //InvokeRepeating("IncreaseSpeed", speedIncreaseInterval, speedIncreaseInterval);
    }

    private void Awake()
    {

        startRotation = transform.rotation;
    }
    private void Update()
    {

        if (!_gameManager.isStarted)
            return;
        isGrounded = IsGrounded();
        SpeedAcc();
        HandleInput();

    }
    private void SpeedAcc()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= 30f)
        {
            currentTime = 0f;
            InvokeRepeating("IncreaseSpeed", speedIncreaseInterval, speedIncreaseInterval);
        }
        if (currentSpeed >= 100f)
        {
            CancelInvoke("IncreaseSpeed");
        }
    }
    private void IncreaseSpeed()
    {

        currentSpeed += speedIncreaseAmount;
    }
    private void MoveForward(float speed)
    {

        _animator.SetBool("isRunning", true);
        _rigidbody.velocity = new Vector3(0, _rigidbody.velocity.y, speed);
    }

    private void HandleInput()
    {
        ApplyGravity();
        HandleMobileInput();
        MoveForward(currentSpeed);
        if (canShift)
        {
            if (Input.GetKeyDown(KeyCode.A) && lane > 1)
            {
                MoveLeft();
            }
            if (Input.GetKeyDown(KeyCode.D) && lane < 3)
            {
                MoveRight();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && canJump)
        {
            Jump();
        }

    }

    private void Jump()
    {
        if (isGrounded)
        {
            _animator.SetBool("isJumping", true);
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _jumpForce, _rigidbody.velocity.z);
            canJump = false;
            StartCoroutine(EnableJump());
        }
    }


    private IEnumerator EnableJump()
    {
        yield return new WaitForSeconds(_jumpCooldown);
        canJump = true;
        _animator.SetBool("isJumping", false);
      
    }

    private void MoveLeft()
    {
        lane--;
        ChangeLane();
    }

    private void MoveRight()
    {
        lane++;
        ChangeLane();
    }

    private void ChangeLane()
    {
        canShift = false;
        float newX = (lane - 2) * _shiftDistance;
        transform.DOMoveX(newX, _shiftDuration).SetEase(Ease.InOutQuint).OnComplete(() =>
        {
            canShift = true; 
        });
    }


   
    protected bool IsGrounded()
    {
        LayerMask groundLayerMask = LayerMask.GetMask("Ground");
        Vector3 checkPosition = checkPoint.transform.position + Vector3.up * groundCheckDistance;

        if (Physics.SphereCast(checkPosition, groundCheckRadius, Vector3.down, out RaycastHit hit, groundCheckDistance, groundLayerMask))
        {
            return true;
        }
        return false;
    }
    private void ApplyGravity()
    {
        _rigidbody.AddForce(Physics.gravity * _gravityScaler, ForceMode.Acceleration);
    }


    private void HandleMobileInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                touchEndPos = touch.position;
                float swipeDistance = Vector2.Distance(touchStartPos, touchEndPos);

                if (swipeDistance > swipeThreshold)
                {
                    Vector2 swipeDirection = (touchEndPos - touchStartPos).normalized;

                    if (swipeDirection.y > 0.8f && isGrounded && canJump)
                    {
                        Jump();
                    }
                    else if (swipeDirection.x < -0.8f && lane > 1)
                    {
                        MoveLeft();
                    }
                    else if (swipeDirection.x > 0.8f && lane < 3)
                    {
                        MoveRight();
                    }
                }
            }
        }
    }
}
