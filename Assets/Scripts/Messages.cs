﻿using System;
using UnityEngine;
using System.Collections.Generic;

namespace Messages
{
	[System.Serializable]
	public class Login
	{
		public const string msgname = "Login";
		public string userId;
		public string password;

		public Login(string userId, string password){
			this.userId = userId;
			this.password = password;
		}
	}

	[System.Serializable]
	public class Register
	{
		public const string msgname = "Register";
		public string userId;
		public string password;

		public Register(string userId, string password){
			this.userId = userId;
			this.password = password;
		}
	}

	[System.Serializable]
	public class Echo
	{
		public const string msgname = "Echo";
		public string msg;

		public Echo(string msg){
			this.msg = msg;
		}
	}

	[System.Serializable]
	public class GetRoles
	{
		public const string msgname = "GetRoles";
		public string userId;

		public GetRoles(string userId){
			this.userId = userId;
		}
	}

	[System.Serializable]
	public class CreateRole
	{
		public const string msgname = "CreateRole";
		public string userId;
		public Role role;

		public CreateRole(string userId, Role role){
			this.userId = userId;
			this.role = role;
		}
	}

	[System.Serializable]
	public class DeleteRole
	{
		public const string msgname = "DeleteRole";
		public string userId;
		public int roleId;

		public DeleteRole(string userId, int roleId){
			this.userId = userId;
			this.roleId = roleId;
		}
	}

	[System.Serializable]
	public class PlayerData
	{
		public const string msgname = "PlayerData";
		public string userId;
		public int roleId;
		public List<double> data;

		public PlayerData(string userId, int roleId, GameObject player){
			this.userId = userId;
			this.roleId = roleId;
			data = new List<double> ();
			Vector3 postion = player.transform.position;
			data.Add (postion.x);data.Add (postion.z);
		}
	}

	[System.Serializable]
	public class EnemyData
	{
		public const string msgname = "EnemyData";
		public List<double> playerData;
		public List<double> enemyData;

		public EnemyData(GameObject player, int id, GameObject enemy){
			playerData = new List<double> ();
			enemyData = new List<double> ();
			playerData.Add (player.transform.position.x);playerData.Add (player.transform.position.z);
			Vector3 postion = enemy.transform.position;
			int type = 0;
			if ("Spider".Equals (enemy.tag))
				type = 0;
			else if ("Mech".Equals (enemy.tag))
				type = 1;
			enemyData.Add (type); enemyData.Add (id); enemyData.Add (postion.x);enemyData.Add (postion.z);
		}
	}

	[System.Serializable]
	public class Damage
	{
		public const string msgname = "Damage";
		public int type;
		public int victim;
		public int id;

		public Damage(int type, int victim, int id = -1){
			this.type = type;
			this.victim = victim;
			this.id = id;
		}
	}

	[System.Serializable]
	public class EnterGame
	{
		public const string msgname = "EnterGame";
		public string userId;
		public int roleId;

		public EnterGame(string userId, int roleId){
			this.userId = userId;
			this.roleId = roleId;
		}
	}

	[System.Serializable]
	public class GetEquipment
	{
		public const string msgname = "GetEquipment";
	}

	[System.Serializable]
	public class Logout
	{
		public const string msgname = "Logout";
		public string userId;

		public Logout(string userId){
			this.userId = userId;
		}
	}
}

