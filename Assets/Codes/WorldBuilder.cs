using UnityEngine;
using System.Collections;

public class WorldBuilder : MonoBehaviour
{

		public GameObject grass;
		public GameObject grass1;
		public GameObject grass2;
		public GameObject grass3;
		public GameObject grass4;
		public GameObject grass5;
		public GameObject map;
		public float rand;

		// Use this for initialization
		void Start ()
		{
				map = GameObject.Find ("Map1");
				int x = 0;
				int y = 0;

				while (x < 50) {
						while (y < 50) {
				rand = Random.value*100;
								// 0  à 30 Grass
								// 31 à 50 Grass1
								// 51 à 70 Grass2
								// 71 à 85 Grass3
								// 86 à 95 Grass4
								// 96 à 100 Grass5

								if (rand <= 30) {		
										GameObject g = Instantiate (grass, new Vector3 (x, y, 0), Quaternion.identity) as GameObject;
										g.name = string.Concat ("Tile", x, "x", y, "_Grass");
										Parent (map, g);
								} else if ((rand > 31) && (rand <= 50)) {
										GameObject g = Instantiate (grass1, new Vector3 (x, y, 0), Quaternion.identity) as GameObject;
										g.name = string.Concat ("Tile", x, "x", y, "_Grass");
										Parent (map, g);
								} else if ((rand > 51) && (rand <= 70)) {
										GameObject g = Instantiate (grass2, new Vector3 (x, y, 0), Quaternion.identity) as GameObject;
										g.name = string.Concat ("Tile", x, "x", y, "_Grass");
										Parent (map, g);
								} else if ((rand > 71) && (rand <= 85)) {
										GameObject g = Instantiate (grass3, new Vector3 (x, y, 0), Quaternion.identity) as GameObject;
										g.name = string.Concat ("Tile", x, "x", y, "_Grass");
										Parent (map, g);
								} else if ((rand > 86) && (rand <= 99)) {
										GameObject g = Instantiate (grass4, new Vector3 (x, y, 0), Quaternion.identity) as GameObject;
										g.name = string.Concat ("Tile", x, "x", y, "_Grass");
										Parent (map, g);
								} else {
										GameObject g = Instantiate (grass5, new Vector3 (x, y, 0), Quaternion.identity) as GameObject;
										g.name = string.Concat ("Tile", x, "x", y, "_Grass");
										Parent (map, g);
								}				
										
								
								y++;		
						}// fin Y
						y = 0;
						x++;
				}//fin X

				
		}
		
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void Parent (GameObject parentOb, GameObject childOb)
		{
				childOb.transform.parent = parentOb.transform;
		}
}
