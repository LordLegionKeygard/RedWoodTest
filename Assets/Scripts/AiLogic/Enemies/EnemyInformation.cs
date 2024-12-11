using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInformation : MonoBehaviour
{
    [SerializeField] private EnemyInfo _enemyInfo;
    public EnemyInfo GetEnemyInfo() => _enemyInfo;
}
