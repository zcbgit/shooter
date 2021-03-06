﻿using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Role {
	public int id;
	public string name;
	public int exp;
	public int level;
	public int maxHP;
	public int HP;
	public int nextLevelExp;
	public string weapon;
	public int attack;
	public int ammunition;

	public override string ToString(){
		return string.Format ("id:{0}, name:(1), level:{2}, blood:{3}, exp:{4}, weapon:{5}, attack:{6}, ammunition:{7}", id, name, level, maxHP, exp, weapon, attack, ammunition);
	}
}
