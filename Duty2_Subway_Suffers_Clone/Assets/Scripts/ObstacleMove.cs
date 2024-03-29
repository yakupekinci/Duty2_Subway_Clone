using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{

    private Rigidbody _rb;
    [SerializeField] private float _speed = 15;
    Vector3 spoint;
    private bool cannMove;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (transform.root.gameObject.activeSelf)
            cannMove = true;
        else
        {
            cannMove = false;
            return;
        }

        _rb.velocity = -transform.forward * _speed;
    }
    private void Start()
    {

        spoint = transform.localPosition;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            player.TakeDamage();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Start"))
        {
            StartCoroutine(ActiveMove());
        }
    }


    IEnumerator ActiveMove()
    {

        cannMove = false;
        transform.position = spoint;
        yield return new WaitForSeconds(3f);
        cannMove = true;

    }
}

