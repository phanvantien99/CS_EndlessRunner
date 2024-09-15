using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private Transform[] lanes;
    [SerializeField] private float switchLaneSpeed;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private CapsuleCollider _collider;
    [SerializeField] public GameManager gameManager;
    [SerializeField] private SoundEffectHolder _soundEffect;

    private int _currentLanes;
    private float degreeToRotate = 0f;

    private IState _currentState;
    private bool _isGrounded;
    public float Speed { get => _speed; set => _speed = value; }
    public int CurrentLanes { get => _currentLanes; set => _currentLanes = value; }
    public float DegreeToRotate { get => degreeToRotate; set => degreeToRotate = value; }
    public Animator Animator { get => _animator; set => _animator = value; }
    public Rigidbody Rb { get => _rb; set => _rb = value; }
    public float JumpHeight { get => _jumpHeight; set => _jumpHeight = value; }
    public bool IsGrounded { get => _isGrounded; set => _isGrounded = value; }
    public CapsuleCollider Collider { get => _collider; set => _collider = value; }
    public SoundEffectHolder SoundEffect { get => _soundEffect; set => _soundEffect = value; }

    private float groundedCheckDistance;
    private float bufferCheckDistance = .1f;

    // Start is called before the first frame update

    private void Awake()
    {
        // 0. Left, 1. Mid, 2. Right
        CurrentLanes = 1;
        _rb = GetComponent<Rigidbody>();
        _currentState = new IdleState();
        _currentState.EnterState(this);
    }
    void Start()
    {
        transform.position = new Vector3(lanes[CurrentLanes].position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateState(this);
        groundedUpdate();
    }

    private void LateUpdate()
    {
        // gameObject.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, new Vector3(lanes[CurrentLanes].position.x, transform.position.y, transform.position.z), switchLaneSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, DegreeToRotate, 0f), .1f);
    }

    public void switchState(IState state)
    {
        _currentState.ExitState(this);
        _currentState = state;
        _currentState.EnterState(this);
    }

    private void groundedUpdate()
    {
        groundedCheckDistance = (_collider.height / 2) + bufferCheckDistance;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, groundedCheckDistance))
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
    }


    // purpose is to finish the animation before do something
    public void startCouroutineCallback(float second, Action<PlayerMovement> callback)
    {
        StartCoroutine(counterTasking(second, callback));
    }

    IEnumerator counterTasking(float second, Action<PlayerMovement> callback)
    {
        yield return new WaitForSeconds(second);
        callback.Invoke(this);
    }


}

