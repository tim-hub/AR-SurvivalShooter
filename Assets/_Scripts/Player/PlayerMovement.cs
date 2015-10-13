using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed=6f;
	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidBody;

	int floorMask;
	float camRayLenght=100f;

	void Awake(){
	
		floorMask=LayerMask.GetMask("Floor");
		anim=GetComponent<Animator>();
		playerRigidBody=GetComponent<Rigidbody>();

	}

	void FixedUpdate(){
		float h=Input.GetAxisRaw("Horizontal");
		float v=Input.GetAxisRaw("Vertical");

		Animating(h,v);
		Move(h,v);
		Turning();

	}


	void Move(float h,float v){
		movement.Set (h,0f,v);

		movement=movement.normalized*speed*Time.deltaTime; //delta time is the time between update
		//use this normalized to avoid 1.4 faster when move / or \ (upleft,upright,downleft,downright)

		playerRigidBody.MovePosition(transform.position+movement);
	}

	void Turning(){
		Ray camRay=Camera.main.ScreenPointToRay(Input.mousePosition);

		RaycastHit floorHit;

		if(Physics.Raycast(camRay, out floorHit, camRayLenght,floorMask)){

			Vector3 playerToMouse =floorHit.point-transform.position;
			playerToMouse.y=0f;


			Quaternion newRotation=Quaternion.LookRotation(playerToMouse);
			playerRigidBody.MoveRotation(newRotation);
		}
	
		
	
	}


	void Animating(float h, float v){
			bool walking=h!=0f ||v!=0f;
			anim.SetBool("isWalking",walking);
	}
}