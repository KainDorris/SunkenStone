﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

[CreateAssetMenu(fileName = "MonsterScriptableObject", menuName = "SunkenStone/MonsterScriptableObject", order = 0)]
public class MonsterScriptableObject : ScriptableObject {
    [Header("Monster Properties")]
    [SerializeField] public float health;
    [SerializeField] public float speed;
    [SerializeField] public float attackSpeed;
    [SerializeField] public float attackCoolDown;
    [SerializeField] public float damage;
    [SerializeField] public float stopDistance;
    [SerializeField] public Sprite sprite;

    [Header("Minion Properties")]
    [SerializeField] public string name;
    [SerializeField] public string description;
    [SerializeField] public bool isCollected;
}
