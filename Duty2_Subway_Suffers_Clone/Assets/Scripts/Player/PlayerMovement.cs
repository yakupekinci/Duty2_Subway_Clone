using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController _characterController;
    private GameManager _gameManager;
    private Animator _animator;
    [SerializeField] private float _moveSpeed = 10f;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _gameManager = FindObjectOfType<GameManager>();
        _animator = transform.GetChild(0).GetComponent<Animator>();
    }
    private void Update()
    {
        if (!_gameManager.isStarted)
            return;

        _animator.SetBool("isRunning", true);
        _characterController.transform.position += _moveSpeed * Time.deltaTime * Vector3.forward;

    }


        



}
