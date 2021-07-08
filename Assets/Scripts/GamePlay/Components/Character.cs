using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Data;
using GamePlay.RuntimeData;
using UnityEngine;

namespace GamePlay.Component
{
    public class Character : MonoBehaviour
    {
        #region Attributes

        [SerializeField] private Movement _movement;

        [SerializeField] private SpellCast _spellCast;
        #endregion
        
        private CharacterData _characterData;

        private Guid _selectSpell;
        public void Initialize(CharacterData characterData, TargetResolver targetResolver, SpellDataBase spellDataBase)
        {
            _characterData = characterData;
            _spellCast.Initialize(spellDataBase, targetResolver);
            _selectSpell = spellDataBase.Spells[0].SpellGuid;
        }

        public void Update()
        {
            Tick(Time.fixedDeltaTime);
        }

        public void UpdateInput(CharacterInput input)
        {
            _movement.UpdateInput(new MovementInput
            {
                Horizontal = (input.Left ? -1 : 0) + (input.Right ? 1 : 0),
                Vertical =(input.Backward ? -1 : 0) + (input.Forward ? 1 : 0),
                Velocity = _characterData.Velocity
            });
            _spellCast.UpdateInput(new SpellCastInput
            {
                SpellGuid = _selectSpell,
                CastKey = input.ActionKey
            });
        }
        
        private void Tick(float deltaTime)
        {
            _movement.Tick(deltaTime);
            _spellCast.Tick(deltaTime);
        }
    }
}
