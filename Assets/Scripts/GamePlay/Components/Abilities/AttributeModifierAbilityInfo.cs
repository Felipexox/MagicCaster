using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Data;
using UnityEngine;

namespace GamePlay.Component.AbilityInfo
{
    public class AttributeModifierAbilityInfo : AbilityInfo
    {
        public override void Initialize(Ability ability, TargetResolver targetResolver)
        {
            base.Initialize(ability, targetResolver);

            foreach (var character in _targetResolverData.Targets)
            {
                if(ability.TempModifier.ModifierGuid != Guid.Empty)
                    character.ApplyTempModifier(ability.TempModifier);
                
                if(ability.PermModifier.ModifierGuid != Guid.Empty)
                    character.ApplyPermModifier(ability.PermModifier);
            }
        }

        public override void Update()
        {
            _ability.Duration -= Time.deltaTime;
            if (_ability.Duration < 0)
            {
                foreach (var character in _targetResolverData.Targets)
                {
                    character.RemoveTempModifier(_ability.TempModifier.ModifierGuid);
                }

                Destroy(gameObject);
            }
        }


    }
}