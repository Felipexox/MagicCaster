using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Data;
using GamePlay.RuntimeData;
using Unity.Collections;
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

        private Attributes _cacheCharacterAttributesModifieds;

        private Guid _selectSpell;

        private List<Modifier> _permModifiers = new List<Modifier>();
        private List<Modifier> _tempModifiers = new List<Modifier>();
        public void Initialize(CharacterData characterData, TargetResolver targetResolver, SpellDataBase spellDataBase)
        {
            _characterData = characterData;
            _spellCast.Initialize(spellDataBase, targetResolver);
            _selectSpell = spellDataBase.Spells[0].SpellGuid;
            
            _cacheCharacterAttributesModifieds = GetCharacterAttributesWithModifiers();
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
                Velocity = _cacheCharacterAttributesModifieds.Velocity
            });
            _spellCast.UpdateInput(new SpellCastInput
            {
                SpellGuid = _selectSpell,
                CastKey = input.ActionKey
            });
        }

        private Attributes GetCharacterAttributesWithModifiers()
        {
            var characterAttributes = _characterData.CharacterAttributes;
            for (int i = 0; i < _tempModifiers.Count; i++)
            {
                characterAttributes = characterAttributes.Add(_tempModifiers[i].ModifierAttributes);
            }
            for (int i = 0; i < _permModifiers.Count; i++)
            {
                characterAttributes = characterAttributes.Add(_permModifiers[i].ModifierAttributes);
            }
            return characterAttributes;
        }

        public void RemoveTempModifier(Guid guid)
        {
            for (int i = _tempModifiers.Count - 1; i >= 0; i--)
            {
                if(_tempModifiers[i].ModifierGuid == guid)
                    _tempModifiers.RemoveAt(i);
            }

            _cacheCharacterAttributesModifieds = GetCharacterAttributesWithModifiers();
        }
        public void ApplyTempModifier(Modifier modifier)
        {
            _tempModifiers.Add(modifier);
            
            _cacheCharacterAttributesModifieds = GetCharacterAttributesWithModifiers();
        }
        public void ApplyPermModifier(Modifier modifier)
        {
            _permModifiers.Add(modifier);
            
            _cacheCharacterAttributesModifieds = GetCharacterAttributesWithModifiers();
        }
        private void Tick(float deltaTime)
        {
            _movement.Tick(deltaTime);
            _spellCast.Tick(deltaTime);
        }
    }
}
