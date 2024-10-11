using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    static private Main S;
    private static Dictionary<eWeaponType, WeaponDefinition> WEAP_DICT;

    [Header("Inscribed")]
    public bool spawnEnemies = true;
    public GameObject[] prefabEnemies;
    public float enemySpawnPerSecond = 0.5f;
    public float enemyInsetDefault = 1.5f;
    public float gameRestartDelay = 2f;
    public WeaponDefinition[] weaponDefinitions;

    private BoundsCheck bndCheck;

    void Awake() {
        S = this;
        bndCheck = GetComponent<BoundsCheck>();
        Invoke(nameof(SpawnEnemy), 1f / enemySpawnPerSecond);

        WEAP_DICT = new Dictionary<eWeaponType, WeaponDefinition>();
        foreach (WeaponDefinition def in weaponDefinitions) {
            WEAP_DICT[def.type] = def;
        }
    }

    public void SpawnEnemy() {
        if (!spawnEnemies) {
            Invoke(nameof(SpawnEnemy), 1f / enemySpawnPerSecond);
            return;
        }
        int ndx = Random.Range(0, prefabEnemies.Length);
        GameObject go = Instantiate<GameObject>(prefabEnemies[ndx]);

        float enemyInset = enemyInsetDefault;
        if (go.GetComponent<BoundsCheck>() != null) {
            enemyInset = Mathf.Abs(go.GetComponent<BoundsCheck>().radius);
        }

        Vector3 pos = Vector3.zero;
        float xMin = -bndCheck.camWidth + enemyInset;
        float xMax = bndCheck.camWidth - enemyInset;
        pos.x = Random.Range(xMin, xMax);
        pos.y = bndCheck.camHeight + enemyInset;
        go.transform.position = pos;

        Invoke(nameof(SpawnEnemy), 1f / enemySpawnPerSecond);
    }

    public void DelayedRestart() {
        Invoke(nameof(Restart), gameRestartDelay);
    }

    public void Restart() {
        SceneManager.LoadScene("__Scene_0");
    }

    static public void HERO_DIED() {
        S.DelayedRestart();
    }

    public static WeaponDefinition GET_WEAPON_DEFINITION(eWeaponType wt) {
        if (WEAP_DICT.ContainsKey(wt)) {
            return WEAP_DICT[wt];
        }

        return new WeaponDefinition();
    }
}
