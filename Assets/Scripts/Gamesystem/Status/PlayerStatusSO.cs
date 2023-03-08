using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerStatusSO : ScriptableObject
{
    [SerializeField] int HP;
    [SerializeField] int MoveSpeed;
    [SerializeField] int Attack1;
    [SerializeField] int Attack2;

    public int hp => HP;
    public int moveSpeed => MoveSpeed;
    public int attack1 => Attack1;
    public int attack2 => Attack2;
}
