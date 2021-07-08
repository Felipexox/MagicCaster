using System;
using GamePlay.Component;
using GamePlay.Data;
using Unity.Collections;
using UnityEngine;

namespace GamePlay.RuntimeData
{
    public struct SpellDataBase
    {
        public NativeArray<Spell> Spells;
        public NativeArray<Ability> Abilities;

        public Ability FindAbility(Guid id)
        {
            for (int i = 0; i < Abilities.Length; i++)
            {
                if (Abilities[i].AbilityGuid == id)
                    return Abilities[i];
            }
            return new Ability();
        }
        public Spell FindSpell(Guid id)
        {
            for (int i = 0; i < Spells.Length; i++)
            {
                if (Spells[i].SpellGuid == id)
                    return Spells[i];
            }
            return new Spell();
        }
    }

    
    public struct TargetResolverData
    {
        public Character OwnerCharacter;
        public Character[] Targets;
        public Vector3 Direction;
    }
    public struct SpellCooldown
    {
        public Guid SpellGuid;
        public float CountDownAccumulator;
    }
    
    public struct SpellCastInput
    {
        public Guid SpellGuid;
        public bool CastKey;
    }
    public struct MovementInput
    {
        public float Horizontal;
        public float Vertical;

        public float Velocity;
    }

    public struct CharacterInput
    {
        public bool Forward;
        public bool Backward;
        public bool Right;
        public bool Left;
        public bool ActionKey;
    }
}