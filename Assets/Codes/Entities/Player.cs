using UnityEngine;
using System.Collections;

public class Player : Entity
{
		string name = "Elievar";
		int vitality = 30;
		int strengh = 10;
		int playerNbActionPoint = 3000;
		
		//0NA 1up 2left 3down 4right
		int direction = 0;
		//0idle 1dead 2run
		int state = 0;
		string message = "";
		public Animator anim;
		public Sprite sprite_1;
		public Sprite sprite_0;

		// Use this for initialization
		void Start ()
		{
				direction = 3;
				state = 0;
				gameObject.GetComponent<SpriteRenderer> ().sprite = sprite_1;
				anim = GetComponent<Animator> ();
				playerToken = true;
		}

		// Update is called once per frame
		void Update ()
		{
				
				if (Input.anyKey) {
						if ((playerNbActionPoint > 0) && (playerToken = true) && (vitality > 0)) { 

	
								if ((Input.GetKey (KeyCode.UpArrow)) || (Input.GetKey (KeyCode.Z))) {
										direction = 1;
										Run (direction);
								}

								if ((Input.GetKey (KeyCode.LeftArrow)) || (Input.GetKey (KeyCode.Q))) {
										direction = 2;
										Run (direction);
								}
			
								if ((Input.GetKey (KeyCode.DownArrow)) || (Input.GetKey (KeyCode.S))) {
										direction = 3;
										Run (direction);
								} 
			
								if ((Input.GetKey (KeyCode.RightArrow)) || (Input.GetKey (KeyCode.D))) {
										direction = 4;
										Run (direction);
								} 
			
								if (Input.GetMouseButtonDown (0)) {
										Attack (direction);
								}
						} else {
				
								// Give token
								playerToken = false;
								enemyToken = true;
				
						}
				} else {

						if (vitality == 0) {
								message = "You are dead. Game Over";					
								gameObject.GetComponent<SpriteRenderer> ().sprite = sprite_0;
						} else {
								state = 0;
								anim.SetInteger ("PlayerAnim", int.Parse (string.Concat (state, direction)));
						}
				}
		}
		
		public void OnGUI ()
		{
			
				// LEFT
				GUI.TextArea (new Rect (Screen.width / 2f - 560 / 2f, Screen.height / 2f + 350 / 2f, 75, 20), string.Concat ("V   : ", vitality.ToString ()));
				GUI.TextArea (new Rect (Screen.width / 2f - 560 / 2f, Screen.height / 2f + 385 / 2f, 75, 20), string.Concat ("AP : ", playerNbActionPoint.ToString ()));
				// CENTER
				GUI.TextArea (new Rect (Screen.width / 2f - 400 / 2f, Screen.height / 2f + 350 / 2f, 400, 50), string.Concat ("", message.ToString ()));
				//RIGHT
				GUI.TextArea (new Rect (Screen.width / 2f + 410 / 2f, Screen.height / 2f + 350 / 2f, 75, 50), string.Concat ("Ahh : ", vitality.ToString ()));

		}

		void OnCollisionEnter2D (Collision2D coll)
		{
				if (coll.gameObject.tag == "Pick") {
						vitality--;
						message = "Outch !";
				}
		}

		void Attack (int direction)
		{
				message = "Yaaahhh !";
		}

		void Run (int direction)
		{
				state = 2;
				if (direction == 1) {
						rigidbody2D.transform.position += Vector3.up * speed * Time.deltaTime;
				}
				if (direction == 2) {
						rigidbody2D.transform.position += Vector3.left * speed * Time.deltaTime;
				}
				if (direction == 3) {
						rigidbody2D.transform.position += Vector3.down * speed * Time.deltaTime;
				}
				if (direction == 4) {
						rigidbody2D.transform.position += Vector3.right * speed * Time.deltaTime;
				}
				anim.SetInteger ("PlayerAnim", int.Parse (string.Concat (state, direction)));
				playerNbActionPoint--;
		}
}
