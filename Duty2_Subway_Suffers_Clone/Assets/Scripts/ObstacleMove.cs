using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{

    private Rigidbody _rb;
    [SerializeField] private float _speed = 15;
    Vector3 spoint;
    bool canMove;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (transform.root.gameObject.activeSelf)
            canMove = true;
        else
        {
            canMove = false;
            return;
        }

        _rb.velocity = -transform.forward * _speed;
    }
    private void Start()
    {

        spoint = transform.position;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            player.TakeDamage();
        }
        if (other.gameObject.CompareTag("Start"))
        {
            canMove=false;
            transform.position = spoint;
            canMove=true;
        }
    }
}

