#if UNITY_ANDROID
    #define USING_MOBILE
#endif

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Vector3 movement;
    private Animator _animator;
    private Rigidbody _rigidbody;
    public float turnSpeed = 20;
    private Vector3 desireForward;
    private Quaternion rotation;
    private AudioSource _audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        #if USING_MOBILE
            float horizontal = Input.GetAxis("Mouse X");
            float vertical = Input.GetAxis("Mouse Y");
            if (Input.touchCount > 0){
                horizontal = Input.touches[0].deltaPosition.x;
                vertical = Input.touches[0].deltaPosition.y;
            }              
        #else
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
        #endif
        movement.Set(horizontal,0,vertical);
        movement.Normalize();
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        _animator.SetBool("IsWalking",isWalking);
        if (isWalking)
        {
            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }
        }
        else
        {
            _audioSource.Stop();
        }
        desireForward = Vector3.RotateTowards(transform.forward, movement, turnSpeed * Time.fixedDeltaTime, 0);
        rotation = Quaternion.LookRotation(desireForward);
    }

    private void OnAnimatorMove()
    {
        _rigidbody.MovePosition(_rigidbody.position + movement * _animator.deltaPosition.magnitude);
        _rigidbody.MoveRotation(rotation);
    }
}
