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
        public Guid ModifierGuid;
        public Attributes ModifierAttributes;
        public float ImpactForce;
    }

    public struct Attributes
    {
        public float Velocity;
        public int Shield;
        public int DamageTake;

        public Attributes Add(Attributes attributes)
        {
            this.Velocity += attributes.Velocity;
            this.Shield += attributes.Shield;
            this.DamageTake += attributes.DamageTake;
            return this;
        }
        public Attributes Sub(Attributes attributes)
        {
            this.Velocity -= attributes.Velocity;
            this.Shield -= attributes.Shield;
            this.DamageTake -= attributes.DamageTake;
            return this;
        }
    }

    public struct CharacterData
    {
        public Attributes CharacterAttributes;
    }
   
}