using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantParallaxor : MonoBehaviour {

	public float SCALING_CONSTANT;
	private MeshRenderer mr;
	private Material material;
	private Vector2 offset;

	void Start () {
		mr = GetComponent<MeshRenderer>();
		material = mr.material;
		offset = material.mainTextureOffset;
	}

	void Update () {
		offset.x += SCALING_CONSTANT * Time.deltaTime / 1000;
		material.mainTextureOffset = offset;
	}
}
