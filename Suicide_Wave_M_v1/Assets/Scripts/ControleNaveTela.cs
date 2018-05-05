using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleNaveTela : MonoBehaviour {

	public Vector3 atualPosicao;

	public Vector3 novaPosicao;

	public float speed;

	RaycastHit hit;
	Ray ray;

	public bool moverOK;



	void Start () {
		atualPosicao = transform.position;
		novaPosicao = transform.position;
	}
	

	void Update () {



		MoverDedo ();
		MoverNave ();
		PermitirMovimento ();
	}

	void MoverDedo(){
		if (moverOK) {
			atualPosicao = transform.position;
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit, 5000, 1 << 8)) {
				
				novaPosicao = new Vector3 (hit.point.x, hit.point.y, transform.position.z);


			}

		}
	}

	void MoverNave(){
		if (moverOK) {
			if (atualPosicao != novaPosicao) {
			
				if (Vector3.Distance (transform.position, novaPosicao) < 5f) {

					transform.position = Vector3.MoveTowards (transform.position, novaPosicao, speed);
				
				} else if (Vector3.Distance (transform.position, novaPosicao) > 5f) {
				
					transform.position = Vector3.MoveTowards (transform.position, novaPosicao, speed * 6f);
				}
			}
		}
	}

	void PermitirMovimento(){
	
		if (Input.GetButtonDown("Fire1")) {
			
		
				moverOK = true;
			
		} else

		if (Input.GetButtonUp("Fire1")) {
			
				moverOK = false;


		}
	}
}
