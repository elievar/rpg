using UnityEngine;
using System.Collections;

public class WorldBuilder : MonoBehaviour {

	public GameObject Grass0;
	//public GameObject TileGrass0;
	//public Transform pos;


	// Use this for initialization
	void Start () {
		Grass0 = Instantiate(Resources.Load<GameObject>("Grass0"), transform.position, transform.rotation) as GameObject;





		/*
		Random.seed = 42;
		noiseValues = new float[10];
		int i = 0;
		while (i < noiseValues.Length) {
			
			noiseValues[i] = Random.value;
			//print(noiseValues[i]);


			i++;
		}
		*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
