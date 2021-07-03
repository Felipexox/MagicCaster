using System;

namespace GamePlay.Model
{
    public struct Spell
    {
        public Guid Id;
        public Guid Ability;
        public float CastTime;
        public float Cooldown;
    }

    public struct Ability
    {
        public Guid Id;
        public Guid VisualInfo;
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

    public struct Character
    {
        public float Velocity;
        public int Shield;
        public int DamageTake;
    }

    public struct MovementInput
    {
        public float Horizontal;
        public float Vertical;

        public float Velocity;
    }
    
}