﻿using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;

    private float _input;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        _input = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = transform.up * (moveSpeed * Time.deltaTime);
        rigidbody.angularVelocity = -_input * (rotateSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Missile"))
        {
            Debug.Log("Game Over");
            Time.timeScale = 0;
        }
    }
}
