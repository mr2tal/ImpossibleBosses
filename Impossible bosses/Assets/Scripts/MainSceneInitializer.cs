using UnityEngine;
using System;

public class MainSceneInitializer : MonoBehaviour {

    public Projectile projectilePrefab;
    public Func<Projectile, Vector3, Quaternion, Projectile> instanciator = Instantiate;
}
