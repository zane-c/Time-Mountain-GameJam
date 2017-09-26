using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxor : MonoBehaviour {

	public float SCALING_CONSTANT;
	private MeshRenderer mr;
	private Material material;
	private Vector2 offset;

	public Transform player;

	void Start () {
		mr = GetComponent<MeshRenderer>();
		material = mr.material;
		offset = material.mainTextureOffset;
	}

	void Update () {
		offset.x = SCALING_CONSTANT * player.position.x / 8000;
		offset.y = SCALING_CONSTANT * player.position.y / 20000;
		material.mainTextureOffset = offset;
	}
}
