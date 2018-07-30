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
        public readonly Action<Vector3> spell;
        public spellRow(Nr3 nr, RoleClass roleClass, KeyRep keyRep, Action<Vector3> spell) {
            this.nr = nr;
            this.roleClass = roleClass;
            this.keyRep = keyRep;
            this.spell = spell;
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
              new spellRow(Nr3.fst, RoleClass.Mage, KeyRep.Q, Spells.FireBolt)
            , new spellRow(Nr3.snd, RoleClass.Mage, KeyRep.Q, Spells.SlowMovingBolt)

        }.AsQueryable();

    public static Action<Vector3> index(Nr3 nr, RoleClass roleclass, KeyRep keyrep) {
        IQueryable<Action<Vector3>> quary = from spellRow row
                                            in FullSpellBook
                                            where row.roleClass == roleclass
                                               && row.nr == nr
                                               && row.keyRep == keyrep
                                            select row.spell;
        return quary.First(); // get first spell in resulting table or crash if none exist.
    }
}