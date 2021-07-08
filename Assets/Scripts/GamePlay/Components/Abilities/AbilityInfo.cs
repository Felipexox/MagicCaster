using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Data;
using GamePlay.RuntimeData;
using UnityEngine;

namespace GamePlay.Component.AbilityInfo
{
    public class AbilityInfo : MonoBehaviour
    {
        protected TargetResolverData _targetResolverData;
        protected Ability _ability;
        public virtual void Initialize(Ability ability, TargetResolver targetResolver)
        {
            _ability = ability;
            _targetResolverData = targetResolver.GetTarget(ability.Target);
        }

        public virtual void Update()
        {
       
        }

    }
}
