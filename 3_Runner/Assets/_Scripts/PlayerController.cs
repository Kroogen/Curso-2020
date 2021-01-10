using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{
    private const string SPEED_F = "Speed_f";
    private const string SPEED_MULIPLIER = "Speed Multiplier";
    private const string JUMP_TRIG = "Jump_trig";
    private const string TAG_GROUND = "Ground";
    private const string TAG_OBSTACLE = "Obstacle";
    private const string DEATH_B = "Death_b";

    private Rigidbody playerRb;
    public int JumpForce = 450;
    public bool inTheGround;

    public bool _gameOver = false;

    private Animator _animator;
    public ParticleSystem explosion;
    public ParticleSystem rastro;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource _audioSource;

    public bool gameOver => _gameOver;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        inTheGround = true;
        _animator = GetComponent<Animator>();
        _animator.SetFloat(SPEED_F,1.0f);
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat(SPEED_MULIPLIER,1);
        
        if (Input.GetKeyDown(KeyCode.A) && inTheGround && !_gameOver)
        {
            playerRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            inTheGround = false;
            rastro.Stop();
            _animator.SetTrigger(JUMP_TRIG);
            _audioSource.pitch = 0.5f;
            _audioSource.PlayOneShot(jumpSound);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(TAG_GROUND))
        {
            inTheGround = true;
            if(!_gameOver)
                rastro.Play();
        }else if (other.gameObject.CompareTag(TAG_OBSTACLE))
        {
            rastro.Stop();
            _gameOver = true;
            explosion.Play();
            _animator.SetBool(DEATH_B,true);
            _audioSource.pitch = 0.5f;
            _audioSource.PlayOneShot(crashSound);
            Invoke("RestartGame",5f);
        }
    }


    void RestartGame()
    {
        SceneManager.LoadScene("Prototype 3");
    }
    
}
