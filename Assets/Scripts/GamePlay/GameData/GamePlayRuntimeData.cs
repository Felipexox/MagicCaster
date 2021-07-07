using System;
using GamePlay.Data;
using Unity.Collections;

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

    public struct SpellCooldown
    {
        public Guid SpellGuid;
        public float CountDownAccumulator;
    }
}