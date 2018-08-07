using UnityEngine;
using UnityEngine.UI;
using Utilities;
using System;

public class CastingSpell : MonoBehaviour {
    public Image castBar;
    public Text castBarTime;

    private float timeCasting = 0f;
    private bool isCasting = false;
    private float castTime;
    private Action<Vector3, GameObject> currentSpell;
    private float globalCooldown = 1f;
    private float[] currentCooldowns = new float[6];
    private int index;
    SpellBook book;

    Spell getSpellByIx(int ix) {
        KeyRep kr = (KeyRep)ix;
        if      (kr == KeyRep.M0) { return book.M0; }
        else if (kr == KeyRep.M1) { return book.M1; }
        else if (kr == KeyRep.Q) { return book.Q; }
        else if (kr == KeyRep.E) { return book.E; }
        else if (kr == KeyRep.R) { return book.R; }
        else if (kr == KeyRep.F) { return book.F; }
        else { throw new Exception("Index does not match a key with a spell on it"); }
    }

    private void Start() {
        TalentSystem.SetSpellsChosen();
        castBar.enabled = false;
        castBarTime.text = "Filler";
        book = GlobalInfo.spellbook;
    }

    private void Update() {
        Action<bool, int, Spell> doIfIxSp = (b, ix, sp) => {
            if (b && currentCooldowns[ix] <= 0) {
                CastRequest(sp.castTime, sp.callable, ix);
            }
        };
        if (!isCasting) {
            doIfIxSp(Input.GetKeyDown(KeyCode.Mouse0), 0, book.M0);
            doIfIxSp(Input.GetKeyDown(KeyCode.Mouse1), 1, book.M1);
            doIfIxSp(Input.GetKeyDown(KeyCode.Q), 2, book.Q);
            doIfIxSp(Input.GetKeyDown(KeyCode.E), 3, book.E);
            doIfIxSp(Input.GetKeyDown(KeyCode.R), 4, book.R);
            doIfIxSp(Input.GetKeyDown(KeyCode.F), 5, book.F);
        }

        bool isTryingToMove = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
        if (isCasting && isTryingToMove) {
            CancelCast();
        }

        if (Input.GetKeyDown(KeyCode.T)) {
            CancelCast();
        }
        if (isCasting) {
            Casting();
        }

        for (int i = 0; i < 6; i++) {
            if (currentCooldowns[i] >= 0) {
                currentCooldowns[i] -= Time.deltaTime;
            }
        }

    }
    public float GetCurrentCooldown(int index) {
        return currentCooldowns[index];
    }

    float GetFullCooldowns(int index) {
        return getSpellByIx(index).cooldown;
    }

    void SetCurrentCooldown(int index) {
        currentCooldowns[index] = currentCooldowns[index] + GetFullCooldowns(index);
    }


    void CastRequest(float castTime, Action<Vector3, GameObject> spell, int index) {
        this.castTime = castTime;
        isCasting = true;
        currentSpell = spell;
        this.index = index;
        for (int i = 0; i < 6; i++) {
            if (currentCooldowns[i] < 0) {
                currentCooldowns[i] = currentCooldowns[i] + globalCooldown;
            }
            else if (currentCooldowns[i] <= 1 && currentCooldowns[i] > 0) {
                currentCooldowns[i] = globalCooldown;
            }
        }
    }

    void Casting() {
        castBar.enabled = true;
        if (timeCasting < castTime) {
            timeCasting = Time.deltaTime + timeCasting;
            castBar.fillAmount = timeCasting / castTime;
            castBarTime.text = Math.Floor(timeCasting) + " / " + castTime;
        }
        else {
            SetCurrentCooldown(index);
            timeCasting = 0f;
            castBar.enabled = false;
            isCasting = false;

            //Shoot projectile
            Vector3 targetCoordinates = VectorFun.GetMouseCoordinatesOnPlane();
            currentSpell(targetCoordinates, gameObject);

        }

    }

    void CancelCast() {
        isCasting = false;
        castBar.enabled = false;
        timeCasting = 0f;
    }
}
