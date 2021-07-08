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

    public enum AbilityTarget
    {
        NoTarget,
        ClosestCharacterLookingFor,
        AllPlayer,
        MouseDirection,
        Caster
    }

    public struct Ability
    {
        public Guid AbilityGuid;
        
        public Guid AssetReferenceGuid;
        
        public AbilityTarget Target;

        public float Duration;
        public bool  DestroyOnCollide;
        public int   Life;
        public float Velocity;
        
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
   
}