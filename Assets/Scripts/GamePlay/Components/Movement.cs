using System.Collections;
using System.Collections.Generic;
using GamePlay.Data;
using UnityEngine;

namespace GamePlay.Component
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        private MovementInput _input;
        
        public void UpdateInput(MovementInput input)
        {
            _input = input;
        }
        public void Tick(float deltaTime)
        {
            _rigidbody.velocity = Vector3.Lerp(_rigidbody.velocity, new Vector3(_input.Horizontal, 0, _input.Vertical) * _input.Velocity, deltaTime * 3);    
        }
    }
}