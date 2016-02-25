using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MoveButtonTouch : MonoBehaviour ,
IBeginDragHandler,IDragHandler,IEndDragHandler,IDropHandler 
{
	//remember turning is with shoot control
	// calculate the h and the v, then give it to PlayerMovement
	
	//public float speed=6f;
	
	//
	//	public GameObject player;
	//	private Animator anim;
	//	private Rigidbody rb;
	public GameObject player;
	
	public float speed=6f;
	
	
	public const float r=45f;
	
	private Vector2 centerPos;
	
	
	private Vector2 newPos;
	
	private Vector3 move3D;
	private Animator anim;
	private bool moving=false;
	
	
	void Start(){
		
		anim=player.GetComponent<Animator>();
		centerPos=GetComponent<RectTransform>().position;

		Debug.Log("RectTransform"+centerPos);
		Debug.Log("Transform"+transform.position);
		
	}
	
	void FixedUpdate () { //rewrite
		if(moving){
			
			Move ();
			
		}
		Animating();
	}
	
	void Move(){
		
		Vector3 move= move3D*speed*Time.deltaTime;
		player.GetComponent<Rigidbody>().MovePosition(player.transform.position+move);
	}
	
	public void Animating(){
		bool walking=player.GetComponent<Rigidbody>().velocity.magnitude !=0f;
		anim.SetBool("isWalking",walking);
	}
	
	public void Test(){
		
		Debug.Log ("Test");
	}
	
	
	public void OnBeginDrag(PointerEventData data){
		
		Debug.Log("Begin Drag");
		
	}
	
	public void OnDrag(PointerEventData data)
	{	
		
		newPos =new Vector2(data.position.x-20f,data.position.y-20f);
		
		//clamp the sprite
		Vector2 diff=newPos-centerPos;
		float distance=diff.magnitude;
		
		if(distance>r){
			newPos=centerPos+diff/distance*r;
			
		}
		GetComponent<RectTransform>().position=newPos;
		//end clamp
		
		//		float x=Mathf.Clamp(newPos.x,-5f,85f);
		//		float y=Mathf.Clamp(newPos.y,-5f,85f);
		//		newPos=new Vector2(x,y);
		
		
		
		
		Vector2 move=newPos-centerPos;
		
		float h=move.x;
		float v=move.y;
		
		move3D=new Vector3(h/r,0f,v/r);
		moving=true;
		
		
		
	}
	
	public void OnEndDrag(PointerEventData data){
		
		Debug.Log("End Drag");
		GetComponent<RectTransform>().position=centerPos;
		moving=false;
		
		
	}
	public void OnDrop(PointerEventData data){
		
		
	}
}