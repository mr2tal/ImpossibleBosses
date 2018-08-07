using Utilities;

public static class GlobalInfo {
    public static LoadingStats player = new LoadingStats("Test Mage", 10, 10, 10);
    public static RoleClass role = RoleClass.Mage;
    public static LoadingStats boss = new LoadingStats("Evil boss", 10, 10, 10);
    public static SpellBook spellbook;
    public static readonly Nr3[] spellsNr = new Nr3[6];
}

public struct LoadingStats {
    public readonly string name;
    public readonly int hp;
    public readonly int mana;
    public readonly float moveSpeed;
    public LoadingStats(string name, int hp, int mana, float moveSpeed) {
        this.name = name;
        this.hp = hp;
        this.mana = mana;
        this.moveSpeed = moveSpeed;
    }
}