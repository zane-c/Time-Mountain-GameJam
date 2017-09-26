using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

		private TimeDilation time;
		public GameObject prefebObj;
		public float delay = 2.0f;

		void Start () {
			StartCoroutine("SpawnObject");
			time = GameObject.Find("FatherTime").GetComponent<TimeDilation> ();
		}

		void Update () {
		}

		IEnumerator SpawnObject() {
			yield return new WaitForSeconds(delay);
			if (!time.isTimeFrozen) {
				Instantiate (
					prefebObj,
					new Vector3(
						transform.position.x,
						transform.position.y,
						transform.position.z
					),
					transform.rotation
				);
			}
			yield return SpawnObject();
		}
}
