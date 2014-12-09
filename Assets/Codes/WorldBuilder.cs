﻿using UnityEngine;
using System.Collections;

public class WorldBuilder : MonoBehaviour
{

		public GameObject grass;
		public GameObject grass1;
		public GameObject grass2;
		public GameObject grass3;
		public GameObject grass4;
		public GameObject grass5;
		public GameObject chest;
		public GameObject tree;
		public GameObject stone;
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
								rand = Random.value * 100;

								// 0  à 30 Grass
								// 31 à 50 Grass1
								// 51 à 70 Grass2
								// 71 à 85 Grass3
								// 86 à 95 Grass4
								// 96 à 100 Grass5

								if (rand < 30) {		
										CreateTile (grass, map, x, y, "Grass");
										rand = Random.value * 100;
										if (rand <= 1) {
												CreateTile (chest, map, x, y, "Chest");
										} else if ((rand > 2) && (rand <= 20)) {
												CreateTile (tree, map, x, y, "Tree");
										} else if ((rand > 21) && (rand <= 30)) {
												CreateTile (stone, map, x, y, "Stone");
										}
								} else if ((rand >= 30) && (rand < 50)) {
										CreateTile (grass1, map, x, y, "Grass1");
								} else if ((rand >= 50) && (rand < 70)) {
										CreateTile (grass2, map, x, y, "Grass2");
								} else if ((rand >= 70) && (rand < 95)) {
										CreateTile (grass3, map, x, y, "Grass3");
								} else if ((rand >= 95) && (rand < 99)) {
										CreateTile (grass4, map, x, y, "Grass4");
								} else {
										CreateTile (grass5, map, x, y, "Grass5");
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

		void CreateTile (GameObject tile, GameObject parent, int posx, int posy, string name)
		{
				GameObject g = Instantiate (tile, new Vector3 (posx, posy, 0), Quaternion.identity) as GameObject;
				g.name = string.Concat (name, "_", posx, "_", posy);
				print (rand);
				Parent (map, g);
		}
}
