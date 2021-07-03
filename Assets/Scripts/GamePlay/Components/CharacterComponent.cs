using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Model;
using UnityEngine;

namespace GamePlay.Component
{
    public class CharacterComponent : MonoBehaviour
    {
        #region Attributes

        [SerializeField] private Movement _movement;
        
        #endregion
        private Character _character;

        public void Initialize(Character character)
        {
            _character = character;
        }

        public void Update()
        {
            Tick(Time.fixedTime);
        }

        private void Tick(float deltaTime)
        {
            _movement.UpdateInput(new MovementInput
            {
                Horizontal = Input.GetAxisRaw("Horizontal"),
                Vertical = Input.GetAxisRaw("Vertical"),
                Velocity = _character.Velocity
            });
            _movement.Tick(deltaTime);
        }
    }
}
