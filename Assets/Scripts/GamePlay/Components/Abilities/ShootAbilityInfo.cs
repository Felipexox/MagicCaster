using System.Collections;
using System.Collections.Generic;
using GamePlay.Data;
using UnityEngine;

namespace GamePlay.Component.AbilityInfo
{
    public class ShootAbilityInfo : AbilityInfo
    {
        public override void Initialize(Ability ability, TargetResolver targetResolver)
        {
            base.Initialize(ability, targetResolver);
            transform.position = _targetResolverData.OwnerCharacter.transform.position;
        }
        
        public override void Update()
        {
            transform.position += _targetResolverData.Direction * (Time.fixedDeltaTime * _ability.Velocity);
        }
    }
}
