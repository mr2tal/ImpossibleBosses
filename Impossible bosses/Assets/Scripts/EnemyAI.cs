using UnityEngine;
using System.Linq;
using Utilities;

public class EnemyAI : MonoBehaviour {
    int timeBetweenShootCounter = shootEveryX; // used to count time between shoots
    public const int shootEveryX = 50;
	
	void FixedUpdate() {
        if (timeBetweenShootCounter <= 0) {
            timeBetweenShootCounter = shootEveryX;
            ShootAtPlayers();
        }
        else {
            timeBetweenShootCounter--;
        }
    }

    void ShootAtPlayers() {
        var players = GameObject.FindGameObjectsWithTag("Players");
        if (players.Length > 0) {
            var aPlayer = players.First();
            SpellHelper.FireBolt(aPlayer.transform.position, gameObject);
        }
    }
}
