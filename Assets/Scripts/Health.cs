using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// 血量控制脚本
public class Health : MonoBehaviour {
	public Slider HPSlider;
	public GameObject DieEffect;
	public AudioClip hitSounds;

	protected int maxHP = 100;
	protected int HP;
	protected AudioSource audioSource;

	private Player net;
	void Start () {
		net = Player.GetInstance ();
		audioSource = GetComponent<AudioSource> ();
	}

	public void Init (int HP){
		this.maxHP = this.HP = HP;
		HPSlider.value = 1.0f;
	}

	// 玩家或怪物被击中后，向服务器发送消息，由服务器计算血量
	public void Hit (string tag) {
		if (HP > 0) {
			int type = -1, victim = -1;
			switch (tag) {
			case "bullet":
				type = 0;
				break;
			case "missile":
				type = 1;
				break;
			default:
				return;
			}
			int id = -1;
			switch (this.gameObject.tag) {
			case "Player":
				victim = 0;
				break;
			case "Spider":
				victim = 1;
				id = this.gameObject.GetComponent<AI> ().id;
				break;
			case "Mech":
				victim = 2;
				id = this.gameObject.GetComponent<AI> ().id;
				break;	
			} 
			string data = Processor.C2SDamage (type, victim, id);
			net.Send (data);
		}
	}

	// 更新血量，如果是扣血还要播放中弹的声音。
	public void UpdateHp(int HP){
		if (HP < this.HP) {
			audioSource.clip = hitSounds;
			audioSource.Play ();
		}
		this.HP = HP;
		HPSlider.value = (float)HP / maxHP;
	}

	public void Die() {
		Instantiate (DieEffect, this.transform.position, this.transform.rotation);
		Destroy (this.gameObject);
	}

}
