using System.Collections.Generic;
using UnityEngine;
public class BattleManager : MonoBehaviour
{
    public const int AFTER_BATTLE_DELAY = 3;

    private List<GameObject> activeEnemies = new List<GameObject>();
    private float battleTimeLeft = 0;


    void Update()
    {
        if (activeEnemies.Count == 0 && battleTimeLeft > 0)
        {
            battleTimeLeft -= Time.deltaTime;
        }
    }

    public void AddEnemy(GameObject enemy)
    {
        this.activeEnemies.Add(enemy);
        this.battleTimeLeft = AFTER_BATTLE_DELAY;
    }

    public bool IsInCombat()
    {
        return activeEnemies.Count > 0 || battleTimeLeft > 0;
    }

    public float GetBattleTimeLeft()
    {
        return this.battleTimeLeft;
    }

    public void RemoveEnemy(GameObject enemy)
    {
        this.activeEnemies.Remove(enemy);
    }
}
