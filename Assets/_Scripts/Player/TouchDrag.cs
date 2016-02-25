using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchDrag : MonoBehaviour {

	public GameObject moveBt;
	public GameObject shootBt;
	public GameObject cube;
	void FixedUpdate () { //rewrite

		
	}


	void Update () {


		if(Input.touchCount>0){


			for (int i=0;i<Input.touches.Length;i++){
				Ray ray=Camera.main.ScreenPointToRay(Input.touches[i].position);


				RaycastHit hit;
				if(Physics.Raycast(ray,out hit)){

					if(hit.transform.gameObject==moveBt||hit.transform.gameObject==shootBt
					   ||hit.transform.gameObject==cube){
						Debug.Log(hit.point);
						Vector3 pos=hit.point;
						pos=new Vector3(pos.x,pos.y,transform.position.z);
						hit.transform.position=pos;

					}

				}
				
			}
			
		}
	}
}