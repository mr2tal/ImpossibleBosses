using UnityEngine;
using System;
using System.Linq;



public class Spellbook {
    Action<Vector3> OnQKey;
    Action<Vector3> OnEKey;
    Action<Vector3> OnRKey;
    Action<Vector3> OnFKey;
    Action<Vector3> OnM0Key;
    Action<Vector3> OnM1Key;

    

    public void castSpell(Vector3 destination, KeyCode key) {
        switch (key) {
            case KeyCode.E:
                OnEKey(destination);
                break;
            case KeyCode.F:
                OnFKey(destination);
                break;
            case KeyCode.Q:
                OnQKey(destination);
                break;
            case KeyCode.R:
                OnRKey(destination);
                break;
            case KeyCode.Mouse0:
                OnM0Key(destination);
                break;
            case KeyCode.Mouse1:
                OnM1Key(destination);
                break;
            default:
                break;
        }
        
    }

    public struct spellRow {
        public readonly Nr3 nr;
        public readonly RoleClass roleClass;
        public readonly KeyRep keyRep;
        public readonly float castTime;
        public readonly float cooldown;
        public readonly Action<Vector3,GameObject> spell;
        public spellRow(Nr3 nr, RoleClass roleClass, KeyRep keyRep, Action<Vector3,GameObject> spell, float castTime, float cooldown) {
            this.nr = nr;
            this.roleClass = roleClass;
            this.keyRep = keyRep;
            this.spell = spell;
            this.castTime = castTime;
            this.cooldown = cooldown;
        }
    }

    public enum RoleClass {
        Ranger,
        Warrior,
        Mage
    }
    public enum KeyRep {
        Q,
        E,
        R,
        F,
        M0,
        M1
    }
    public enum Nr3 {
        fst,
        snd,
        thr
    }

    public static IQueryable<spellRow> FullSpellBook = new spellRow[] {
              new spellRow(Nr3.fst, RoleClass.Mage, KeyRep.M0, Spells.FireBolt, 1f, 1f)
            , new spellRow(Nr3.snd, RoleClass.Mage, KeyRep.M0, Spells.SlowMovingBolt, 2f, 2f)
            , new spellRow(Nr3.thr, RoleClass.Mage, KeyRep.M0, Spells.ShortBolt, 3f, 3f)
            , new spellRow(Nr3.fst, RoleClass.Mage, KeyRep.M1, Spells.FireBolt, 1f, 1f)
            , new spellRow(Nr3.snd, RoleClass.Mage, KeyRep.M1, Spells.SlowMovingBolt, 2f, 2f)
            , new spellRow(Nr3.thr, RoleClass.Mage, KeyRep.M1, Spells.ShortBolt, 3f, 3f)
            , new spellRow(Nr3.fst, RoleClass.Mage, KeyRep.Q, Spells.FireBolt, 1f, 1f)
            , new spellRow(Nr3.snd, RoleClass.Mage, KeyRep.Q, Spells.SlowMovingBolt, 2f, 2f)
            , new spellRow(Nr3.thr, RoleClass.Mage, KeyRep.Q, Spells.ShortBolt, 3f, 3f)
            , new spellRow(Nr3.fst, RoleClass.Mage, KeyRep.E, Spells.FireBolt, 1f, 1f)
            , new spellRow(Nr3.snd, RoleClass.Mage, KeyRep.E, Spells.SlowMovingBolt, 2f, 2f)
            , new spellRow(Nr3.thr, RoleClass.Mage, KeyRep.E, Spells.ShortBolt, 3f, 3f)
            , new spellRow(Nr3.fst, RoleClass.Mage, KeyRep.R, Spells.FireBolt, 1f, 1f)
            , new spellRow(Nr3.snd, RoleClass.Mage, KeyRep.R, Spells.SlowMovingBolt, 2f, 2f)
            , new spellRow(Nr3.thr, RoleClass.Mage, KeyRep.R, Spells.ShortBolt, 3f, 3f)
            , new spellRow(Nr3.fst, RoleClass.Mage, KeyRep.F, Spells.FireBolt, 1f, 1f)
            , new spellRow(Nr3.snd, RoleClass.Mage, KeyRep.F, Spells.SlowMovingBolt, 2f, 2f)
            , new spellRow(Nr3.thr, RoleClass.Mage, KeyRep.F, Spells.ShortBolt, 3f, 3f)
            ,

        }.AsQueryable();

    public static Action<Vector3,GameObject> index(Nr3 nr, RoleClass roleclass, KeyRep keyrep) {
        IQueryable<Action<Vector3,GameObject>> quary = from spellRow row
                                            in FullSpellBook
                                            where row.roleClass == roleclass
                                               && row.nr == nr
                                               && row.keyRep == keyrep
                                            select row.spell;
        return quary.First(); // get first spell in resulting table or crash if none exist.
    }

    public static float CastTime(KeyRep keyrep, Action<Vector3, GameObject> spell)  {
        IQueryable<float> quary =               from spellRow row
                                                in FullSpellBook
                                                 where row.spell == spell
                                                 && row.keyRep == keyrep
                                                 select row.castTime;
        return quary.First(); // get first spell in resulting table or crash if none exist.
    }

    public static float Cooldown(KeyRep keyrep, Action<Vector3, GameObject> spell)
    {
        IQueryable<float> quary = from spellRow row
                                  in FullSpellBook
                                  where row.spell == spell
                                  && row.keyRep == keyrep
                                  select row.cooldown;
        return quary.First(); // get first spell in resulting table or crash if none exist.
    }
}