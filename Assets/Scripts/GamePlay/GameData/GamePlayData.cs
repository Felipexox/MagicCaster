using System;

namespace GamePlay.Data
{
    public struct Spell
    {
        public Guid SpellGuid;
        public Guid AbilityGuid;
        public float CastTime;
        public float Cooldown;
    }

    public struct Ability
    {
        public Guid AbilityGuid;
        public Guid VisualInfoGuid;
        public Modifier TempModifier;
        public Modifier PermModifier;
    }
    
    public struct Modifier
    {
        public float Velocity;
        public int Shield;
        public int DamageTake;
        public float ImpactForce;
    }

    public struct CharacterData
    {
        public float Velocity;
        public int Shield;
        public int DamageTake;
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