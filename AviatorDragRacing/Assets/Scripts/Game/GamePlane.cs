using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlane : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _plane;
    private float _startingSpeed;
    private float _accelerationSpeed;
    private float _stability;
    private float _pilotLevel;

    private float _currentSpeed = 0;
    private bool _isFlying = false;
    private float _randomMult;
    private void Start()
    {
        _randomMult = Random.Range(0.9f, 1.1f);
    }
    private void Update()
    {
        if(_isFlying)
        {
            _currentSpeed += _accelerationSpeed * (_pilotLevel / 2.0f) * _randomMult * Time.deltaTime;

            float newPosition = transform.position.x + _currentSpeed * Time.deltaTime;

            transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
        }
    }
    public void InitializePlane(int startSpeed, int accelerationSpeed, int stability, int pilotLevel, Sprite plane)
    {
        _plane.sprite = plane;

        _startingSpeed = startSpeed;
        _accelerationSpeed = accelerationSpeed;
        _stability = stability;
        _pilotLevel = pilotLevel;

        _currentSpeed = _startingSpeed;
    }
    public void SetFly()
    {
        _isFlying = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            _isFlying = false;
        }
    }

}
