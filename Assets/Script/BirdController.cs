using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private float _flapforce = 5f;
    private bool _isAlive = true;
    [SerializeField] private float _yBounds = -5f;
    [SerializeField] private float _topBounds = 6f;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

   
    public void Flap()
    {
        if (_isAlive)
        {
            
            _rb2d.velocity = Vector2.zero;
            _rb2d.velocity = Vector2.up * _flapforce;
   
        }
    }

    public void Die()
    {
        if (!_isAlive) return;
        _isAlive = false;
        //Debug.Log("Die!");
        GameManager.Instance.GameOver();
    }
   
    void Update()
    {
        if (!GameManager.Instance.IsGameStarted()) return;
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Flap();
        }
        if (_isAlive && transform.position.y < _yBounds || transform.position.y > _topBounds)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        Die();
    }
   
}
