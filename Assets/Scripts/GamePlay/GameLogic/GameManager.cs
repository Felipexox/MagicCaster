using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Component;
using GamePlay.Data;
using GamePlay.RuntimeData;
using Unity.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace GamePlay.Logic
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Character[] Characters = new Character[0];
        [SerializeField] private AssetReference _spellReference;
        [SerializeField] private TargetResolver _targetResolver;
        
        private Character[] InGameCharacters;

        private SpellDataBase _spellDataBase;
        
        
        private void Start()
        {
            _spellDataBase = new SpellDataBase
            {
                Abilities = new NativeArray<Ability>(2, Allocator.Persistent),
                Spells = new NativeArray<Spell>(2, Allocator.Persistent),
            };
            for (int i = 0; i < _spellDataBase.Abilities.Length; i++)
            {
                _spellDataBase.Abilities[i] = new Ability
                {
                    Target = AbilityTarget.MouseDirection,
                    Duration = 3,
                    Velocity = 15,
                    AbilityGuid = Guid.NewGuid(),
                    TempModifier = new Modifier
                    {
                        ModifierGuid = Guid.NewGuid(),
                        ModifierAttributes = new Attributes
                        {
                            Velocity = -10
                        }
                    },
                    PermModifier = new Modifier
                    {
                        ModifierGuid = Guid.NewGuid(),
                        ModifierAttributes = new Attributes
                        {
                            Velocity = 5
                        }
                    },
                    AssetReferenceGuid = new Guid(_spellReference.AssetGUID)
                };
                _spellDataBase.Spells[i] = new Spell
                {
                    AbilityGuid = _spellDataBase.Abilities[i].AbilityGuid,
                    SpellGuid = Guid.NewGuid(),
                    Cooldown = 2f,
                    CastTime = 1f
                };      
            }
            InGameCharacters = new Character[Characters.Length];
            _targetResolver.Initialize(InGameCharacters);
                
            for (int i = 0; i < Characters.Length; i++)
            {
                InGameCharacters[i] = Instantiate(Characters[i]);
                InGameCharacters[i].Initialize(new CharacterData
                {
                   CharacterAttributes = new Attributes
                   {
                       Velocity = 10,
                       Shield = 100,
                       DamageTake = 0
                   }
                }, _targetResolver, _spellDataBase);
            }
            
         
        }

        private void Update()
        {
            for (int i = 0; i < InGameCharacters.Length; i++)
            {
                InGameCharacters[i].UpdateInput(new CharacterInput
                {
                    Left = Input.GetAxisRaw("Horizontal") < 0,
                    Backward = Input.GetAxisRaw("Vertical") < 0,
                    Right = Input.GetAxisRaw("Horizontal") > 0,
                    Forward = Input.GetAxisRaw("Vertical") > 0,
                    ActionKey = Input.GetKeyDown(KeyCode.Space)
                });
                
            }
        }
    }

}
