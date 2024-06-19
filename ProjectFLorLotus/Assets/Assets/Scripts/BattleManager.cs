using System.Collections.Generic;
using UnityEngine;
public class BattleManager : MonoBehaviour
{
    public List<GameObject> activeEnemies = new List<GameObject>();

    public void AddEnemy(GameObject enemy)
    {
        this.activeEnemies.Add(enemy);
    }

    public bool IsInCombat()
    {
        return activeEnemies.Count > 0;
    }

    public void RemoveEnemy(GameObject enemy)
    {
        this.activeEnemies.Remove(enemy);
    }
}
