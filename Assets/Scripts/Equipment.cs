﻿using UnityEngine;
using System.Collections;

// 装备盒子处理脚本。
public class Equipment : MonoBehaviour {
	private Player net; 
	// Use this for initialization
	void Start () {
		net = Player.GetInstance ();
	}

	// 玩家碰撞盒子，就获得盒子的资源
	void OnTriggerEnter (Collider other) {
		if ("Player".Equals(other.gameObject.tag)) {
			string data = Processor.C2SGetEquipment ();
			net.Send (data);
			Destroy (this.gameObject);
		}
	}
}
