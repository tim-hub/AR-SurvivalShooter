using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ShootButtonTouch : MonoBehaviour ,
IBeginDragHandler,IDragHandler,IEndDragHandler,IDropHandler ,IPointerDownHandler,IPointerUpHandler
{
	//remember turning is with shoot control
	// calculate the h and the v, then give it to PlayerMovement


	public GameObject player;
	public GameObject gun;

	//public float rotateSpeed=6f;

	public const float r=100f;

	private Vector2 centerPos;


	private Vector2 newPos;

	private float angle;



	
	void Start(){


		centerPos=GetComponent<RectTransform>().position;
		
		Debug.Log("Centerpos"+centerPos);
	}



	void Rotate(float angle){


		Debug.Log(angle);


		Quaternion newRotation=Quaternion.Euler(new Vector3(player.transform.localRotation.x,
		                                                    angle,
		                                                    player.transform.localRotation.z));


		player.transform.localRotation=newRotation;

	}




	public void OnBeginDrag(PointerEventData data){
		
		Debug.Log("Begin Drag");

	}
	
	public void OnDrag(PointerEventData data)
	{	


		newPos =new Vector2(data.position.x+20f,data.position.y-20f);

		//clamp the sprite
		Vector2 diff=newPos-centerPos;
		float distance=diff.magnitude;

		if(distance>r){
			newPos=centerPos+diff/distance*r;

		}
		GetComponent<RectTransform>().position=newPos;
		//end clamp


		//calculate the angle
		float x=diff.x;
		float y=diff.y;

		angle=Mathf.Acos(x/Mathf.Sqrt(x*x+y*y));





		float a=angle/Mathf.PI*180f;
		if(y<0f){
			a=-a;
		}


		Rotate(90f-a); 


		
	}
	
	public void OnEndDrag(PointerEventData data){

		Debug.Log("End Drag");
		GetComponent<RectTransform>().position=centerPos;
		//rotating=false;
		
		
	}
	public void OnDrop(PointerEventData data){


	}

	public void OnPointerDown(PointerEventData data){

		PlayerShooting.instance.shooting=true;
	}

	public void OnPointerUp(PointerEventData data){
		
		PlayerShooting.instance.shooting=false;
	}
}
