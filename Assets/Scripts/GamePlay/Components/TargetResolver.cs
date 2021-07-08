using System.Collections;
using System.Collections.Generic;
using GamePlay.Data;
using GamePlay.RuntimeData;
using UnityEngine;

namespace GamePlay.Component
{
    public class TargetResolver : MonoBehaviour
    {
        private Character[] _characters;
        
        public void Initialize(Character[] characters)
        {
            _characters = characters;
        }
        public TargetResolverData GetTarget(AbilityTarget abilityTarget)
        {
            return new TargetResolverData
            {
                OwnerCharacter = _characters[0],
                Targets = _characters,
                Direction = _characters[0].transform.forward,
            };;
        }
    }
}