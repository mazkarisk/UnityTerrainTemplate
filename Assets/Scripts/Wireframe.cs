using NUnit.Framework.Internal;
using System.Collections.Generic;
using UnityEngine;

public class Wireframe : MonoBehaviour {
	[SerializeField]
	Material wireframeMaterial;

	void Start() {
		// ワイヤフレーム用のGameObjectを準備する
		GameObject go = new GameObject("Wireframe");
		go.transform.parent = transform;
		go.transform.localPosition = Vector3.zero;
		go.transform.localRotation = Quaternion.identity;
		go.transform.localScale = Vector3.one;

		Mesh mesh = GetComponent<MeshFilter>().mesh;

		List<int> indices = new List<int>();
		for (int i = 0; i < mesh.GetIndices(0).Length / 3; i++) {
			indices.Add(mesh.GetIndices(0)[i * 3 + 0]);
			indices.Add(mesh.GetIndices(0)[i * 3 + 1]);
			indices.Add(mesh.GetIndices(0)[i * 3 + 1]);
			indices.Add(mesh.GetIndices(0)[i * 3 + 2]);
			indices.Add(mesh.GetIndices(0)[i * 3 + 2]);
			indices.Add(mesh.GetIndices(0)[i * 3 + 0]);
		}

		MeshFilter meshFilter = go.AddComponent<MeshFilter>();
		meshFilter.mesh = mesh;
		meshFilter.mesh.SetIndices(indices, MeshTopology.Lines, 0);

		MeshRenderer meshRenderer = go.AddComponent<MeshRenderer>();
		meshRenderer.material = wireframeMaterial;
	}
}
