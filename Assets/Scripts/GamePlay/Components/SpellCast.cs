using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Data;
using GamePlay.RuntimeData;
using GamePlay.Utility;
using Unity.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace GamePlay.Component
{
    public class SpellCast : MonoBehaviour
    {
        private SpellCastInput _input;
        private SpellDataBase _spellDataBase;

        private NativeArray<SpellCooldown> _spellCooldown;
        public void Initialize(SpellDataBase spellDataBase)
        {
            _spellDataBase = spellDataBase;
            _spellCooldown = new NativeArray<SpellCooldown>(_spellDataBase.Spells.Length, Allocator.Persistent);
        }
        
        public void UpdateInput(SpellCastInput input)
        {
            _input = input;
        }
        public void Tick(float deltaTime)
        {
            TickSpellCast(_input.SpellGuid, _input.CastKey);
            TickSpellCooldown(deltaTime);
        }

        public IEnumerator CastSpell(Spell spell, SpellDataBase dataBase)
        {
            yield return new WaitForSeconds(spell.CastTime);
            
            yield return StartCoroutine(CastAbility(spell.AbilityGuid, dataBase));
        }

        private IEnumerator CastAbility(Guid id, SpellDataBase database)
        {
            var ability = database.FindAbility(id);
            
            var visualInfoGuidStr = VisualInfoUtility.FormatAddressableGuid(ability.VisualInfoGuid);
            
            var visualInfoAssetReference = new AssetReference(visualInfoGuidStr);

            yield return visualInfoAssetReference.LoadAssetAsync<GameObject>();

            var asset = visualInfoAssetReference.Asset as GameObject;

            Instantiate(asset);
        }

        private void TickSpellCast(Guid spellGuid, bool inputCastKey)
        {
            if(!inputCastKey)
                return;
            
            for (int i = 0; i < _spellCooldown.Length; i++)
            {
                if (spellGuid == _spellCooldown[i].SpellGuid)
                    return;
            }

            var spell = _spellDataBase.FindSpell(spellGuid);
            
            for (int i = 0; i < _spellCooldown.Length; i++)
            {
                if (_spellCooldown[i].SpellGuid == Guid.Empty)
                {
                    _spellCooldown[i] = new SpellCooldown
                    {
                        SpellGuid = spellGuid,
                        CountDownAccumulator = spell.Cooldown
                    };
                    break;
                }
            }
            StartCoroutine(CastSpell(spell, _spellDataBase));
        }
        private void TickSpellCooldown(float deltaTime)
        {
            for (int i = 0; i < _spellCooldown.Length; i++)
            {
                if(_spellCooldown[i].SpellGuid == Guid.Empty)
                    continue;
                
                var spellCooldown = _spellCooldown[i];
                spellCooldown.CountDownAccumulator -= deltaTime;
                
                if(spellCooldown.CountDownAccumulator <= 0)
                    spellCooldown.SpellGuid = Guid.Empty;
                
                _spellCooldown[i] = spellCooldown;
            }
        }

    }
}