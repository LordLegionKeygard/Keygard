using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float walkDistance = 6f;
    [SerializeField] private float walkSpeed = 1f;
    [SerializeField] private float chasingSpeed = 2f;
    [SerializeField] private float timeToWait = 3f;
    [SerializeField] private float timeToChase = 5f;
    [SerializeField] private float minimumDistanceToPlayer = 1.5f;

    private Transform _playerTransform;
    private Rigidbody2D _rb;
    private Vector2 _leftBoundaryPosition;
    private Vector2 _rightBoundaryPosition;
    private Vector2 _nextPoint;

    private bool _isWait = false;
    private float _waitTime;
    private float _chaseTime;
    private bool _isFacingRight = true;
    private bool _isChasingPlayer = false;
    private float _multiplier = 1;
    private float _originalWalkSpeed;

    public bool IsFacingRight {
        get => _isFacingRight;
    }

    public void StartChasingPlayer() {
        _isChasingPlayer = true;
        _chaseTime = timeToChase;
    }

    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        _leftBoundaryPosition = transform.position;
        _rightBoundaryPosition = _leftBoundaryPosition + Vector2.right * walkDistance;

        _originalWalkSpeed = walkSpeed;
        _waitTime = timeToWait;
        _chaseTime = timeToChase;
    }

    private void Update() {
        
        Debug.DrawLine(_leftBoundaryPosition, _rightBoundaryPosition, Color.red);
        
        if(_isWait){
            StartWaitTimer();
        }
        if(_isChasingPlayer){
            StartChasingTimer();
        }
        
        if(ShouldWait() && !_isChasingPlayer) {
            _isWait = true;
        }
    }

    private void FixedUpdate() {
        _nextPoint =  Vector2.right * walkSpeed * Time.fixedDeltaTime;

        if(Mathf.Abs(DistanceBetweenPlayerAndEnemy()) <= minimumDistanceToPlayer) {
            return;
        }

        if(_isChasingPlayer) {
            walkSpeed = chasingSpeed;
            ChasePlayer();
        }
        else {
            walkSpeed = _originalWalkSpeed;
        }
        
        if(!_isWait && !_isChasingPlayer) {
            Patrol();
        }
    }

    private void StartChasingTimer() {
        _chaseTime -= Time.deltaTime;

        if(_chaseTime < 0) {
            _isChasingPlayer = false;
            _chaseTime = timeToChase;
        }
    }

    private void Patrol () {
        _multiplier = !_isFacingRight ? -1 : 1;
        _nextPoint.x *= _multiplier;
        _rb.MovePosition((Vector2)transform.position + _nextPoint);
    }

    private void ChasePlayer() {
        float distance = DistanceBetweenPlayerAndEnemy();
        if(distance > 0.2f && !_isFacingRight) {
            Flip();
        }
        else if(distance < -0.2f && _isFacingRight) {
            Flip();
        }

        _multiplier = distance > 0 ? 1 : -1;
        _nextPoint.x *= _multiplier;
        _rb.MovePosition((Vector2)transform.position + _nextPoint);
    }
    
    private float DistanceBetweenPlayerAndEnemy() {
        return _playerTransform.position.x - transform.position.x;
    }

    private bool ShouldWait() {
        bool isOutOfRightBoundary = _isFacingRight && transform.position.x >= _rightBoundaryPosition.x;
        bool isOutOfLeftBoundary = !_isFacingRight && transform.position.x <= _leftBoundaryPosition.x;

        return isOutOfLeftBoundary || isOutOfRightBoundary;
    }

    private void StartWaitTimer() {
        _waitTime -= Time.deltaTime;

        if(_waitTime < 0) {
            _isWait = false;
            _waitTime = timeToWait;
            Flip();
        }
    }

    void Flip() {
        _isFacingRight = !_isFacingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

}
