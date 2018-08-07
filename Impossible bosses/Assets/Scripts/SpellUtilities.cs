using UnityEngine;
using System;
using System.Linq;

namespace Utilities {
    public enum RoleClass {
        Ranger,
        Warrior,
        Mage
    }
    public enum KeyRep {
        M0,
        M1,
        Q,
        E,
        R,
        F
    }
    public enum Nr3 {
        fst = 0,
        snd = 1,
        thr = 2
    }

    public struct SpellBook {
        public readonly Spell Q;
        public readonly Spell E;
        public readonly Spell R;
        public readonly Spell F;
        public readonly Spell M0;
        public readonly Spell M1;
        public SpellBook(Spell m0, Spell m1, Spell q, Spell e, Spell r, Spell f) {
            M0 = m0;
            M1 = m1;
            Q = q;
            E = e;
            R = r;
            F = f;
        }
    }

    public struct Spell {
        public readonly float castTime;
        public readonly float cooldown;
        public readonly Action<Vector3, GameObject> callable;
        public Spell(Action<Vector3, GameObject> spell, float castTime, float cooldown) {
            callable = spell;
            this.castTime = castTime;
            this.cooldown = cooldown;
        }
    }

    public struct SpellRow {
        public readonly Nr3 nr;
        public readonly RoleClass roleClass;
        public readonly KeyRep keyRep;
        public readonly Spell spell;
        public SpellRow(Nr3 nr, RoleClass roleClass, KeyRep keyRep, Spell spell) {
            this.nr = nr;
            this.roleClass = roleClass;
            this.keyRep = keyRep;
            this.spell = spell;
        }

        // nr3 = spellnumber, roleclass = player class, keyrep is what button it represent, spell = spell, cast time , cooldown, can it be casted on move?
        public static readonly IQueryable<SpellRow> FullSpellBook = new SpellRow[] {
              new SpellRow(Nr3.fst, RoleClass.Mage,    KeyRep.M0, new Spell(SpellHelper.FireBolt, 1f, 1f))
            , new SpellRow(Nr3.snd, RoleClass.Mage,    KeyRep.M0, new Spell(SpellHelper.SlowMovingBolt, 2f, 2f))
            , new SpellRow(Nr3.thr, RoleClass.Mage,    KeyRep.M0, new Spell(SpellHelper.ShortBolt, 3f, 3f))
            , new SpellRow(Nr3.fst, RoleClass.Mage,    KeyRep.M1, new Spell(SpellHelper.standardBolt, 1f, 1f))
            , new SpellRow(Nr3.snd, RoleClass.Mage,    KeyRep.M1, new Spell(SpellHelper.standardBolt, 2f, 2f))
            , new SpellRow(Nr3.thr, RoleClass.Mage,    KeyRep.M1, new Spell(SpellHelper.standardBolt, 3f, 3f))
            , new SpellRow(Nr3.fst, RoleClass.Mage,    KeyRep.Q,  new Spell(SpellHelper.standardBolt, 1f, 1f))
            , new SpellRow(Nr3.snd, RoleClass.Mage,    KeyRep.Q,  new Spell(SpellHelper.standardBolt, 2f, 2f))
            , new SpellRow(Nr3.thr, RoleClass.Mage,    KeyRep.Q,  new Spell(SpellHelper.standardBolt, 3f, 3f))
            , new SpellRow(Nr3.fst, RoleClass.Mage,    KeyRep.E,  new Spell(SpellHelper.standardBolt, 1f, 1f))
            , new SpellRow(Nr3.snd, RoleClass.Mage,    KeyRep.E,  new Spell(SpellHelper.standardBolt, 2f, 2f))
            , new SpellRow(Nr3.thr, RoleClass.Mage,    KeyRep.E,  new Spell(SpellHelper.standardBolt, 3f, 3f))
            , new SpellRow(Nr3.fst, RoleClass.Mage,    KeyRep.R,  new Spell(SpellHelper.standardBolt, 1f, 1f))
            , new SpellRow(Nr3.snd, RoleClass.Mage,    KeyRep.R,  new Spell(SpellHelper.standardBolt, 2f, 2f))
            , new SpellRow(Nr3.thr, RoleClass.Mage,    KeyRep.R,  new Spell(SpellHelper.standardBolt, 3f, 3f))
            , new SpellRow(Nr3.fst, RoleClass.Mage,    KeyRep.F,  new Spell(SpellHelper.standardBolt, 1f, 1f))
            , new SpellRow(Nr3.snd, RoleClass.Mage,    KeyRep.F,  new Spell(SpellHelper.standardBolt, 2f, 2f))
            , new SpellRow(Nr3.thr, RoleClass.Mage,    KeyRep.F,  new Spell(SpellHelper.standardBolt, 3f, 3f))
            , new SpellRow(Nr3.fst, RoleClass.Warrior, KeyRep.M0, new Spell(SpellHelper.Melee(5), 0, 0.1f))
            , new SpellRow(Nr3.snd, RoleClass.Warrior, KeyRep.M0, new Spell(SpellHelper.Melee(5), 0, 0.1f))
            , new SpellRow(Nr3.thr, RoleClass.Warrior, KeyRep.M0, new Spell(SpellHelper.Melee(5), 0, 0.1f))
            , new SpellRow(Nr3.fst, RoleClass.Warrior, KeyRep.M1, new Spell(SpellHelper.Melee(5), 0, 0.1f))
            , new SpellRow(Nr3.snd, RoleClass.Warrior, KeyRep.M1, new Spell(SpellHelper.Melee(5), 0, 0.1f))
            , new SpellRow(Nr3.thr, RoleClass.Warrior, KeyRep.M1, new Spell(SpellHelper.Melee(5), 0, 0.1f))
            , new SpellRow(Nr3.fst, RoleClass.Warrior, KeyRep.Q,  new Spell(SpellHelper.Melee(5), 0, 0.1f))
            , new SpellRow(Nr3.snd, RoleClass.Warrior, KeyRep.Q,  new Spell(SpellHelper.Melee(5), 0, 0.1f))
            , new SpellRow(Nr3.thr, RoleClass.Warrior, KeyRep.Q,  new Spell(SpellHelper.Melee(5), 0, 0.1f))
            , new SpellRow(Nr3.fst, RoleClass.Warrior, KeyRep.E,  new Spell(SpellHelper.Melee(5), 0, 0.1f))
            , new SpellRow(Nr3.snd, RoleClass.Warrior, KeyRep.E,  new Spell(SpellHelper.Melee(5), 0, 0.1f))
            , new SpellRow(Nr3.thr, RoleClass.Warrior, KeyRep.E,  new Spell(SpellHelper.Melee(5), 0, 0.1f))
            , new SpellRow(Nr3.fst, RoleClass.Warrior, KeyRep.R,  new Spell(SpellHelper.Melee(5), 0, 0.1f))
            , new SpellRow(Nr3.snd, RoleClass.Warrior, KeyRep.R,  new Spell(SpellHelper.Melee(5), 0, 0.1f))
            , new SpellRow(Nr3.thr, RoleClass.Warrior, KeyRep.R,  new Spell(SpellHelper.Melee(5), 0, 0.1f))
            , new SpellRow(Nr3.fst, RoleClass.Warrior, KeyRep.F,  new Spell(SpellHelper.Melee(5), 0, 0.1f))
            , new SpellRow(Nr3.snd, RoleClass.Warrior, KeyRep.F,  new Spell(SpellHelper.Melee(5), 0, 0.1f))
            , new SpellRow(Nr3.thr, RoleClass.Warrior, KeyRep.F,  new Spell(SpellHelper.Melee(5), 0, 0.1f))

        }.AsQueryable();

        public static Spell index(Nr3 nr, RoleClass rc, KeyRep kr) {
            IQueryable<Spell> quary = from SpellRow row
                                      in FullSpellBook
                                      where row.roleClass == rc
                                         && row.nr == nr
                                         && row.keyRep == kr
                                      select row.spell;
            return quary.First(); // get first spell in resulting table or throw exception if none exist.
        }
    }
}