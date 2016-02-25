using UnityEngine;
using System.Collections;

public class StatePatternEnermy : MonoBehaviour {

	public float searchingTurnSpeed=120f;
	public float searchingDuration=4f;
	public float sightRange=20f;
	public Transform[] wayPoints;
	public Transform eyes;
	public Vector3 offSet=new Vector3(0f,0.5f,0f);
	public MeshRenderer meshRndererFlag;

	[HideInInspector]public Transform chaseTarget;
	[HideInInspector]public IEnermyState currentState;
	[HideInInspector]public ChaseState chaseState;
	[HideInInspector]public AlertState alertState;
	[HideInInspector]public PatrolState patrolState;
	[HideInInspector]public NavMeshAgent navMeshAgent;
	// Use this for initialization
	void Awake () {
		chaseState=new ChaseState(this);
		alertState=new AlertState(this);
		patrolState=new PatrolState(this);

		navMeshAgent=this.GetComponent<NavMeshAgent>();
	}

	void Start(){
		currentState=patrolState;
	}

	// Update is called once per frame
	void Update () {
		currentState.UpdateState();
	
	}

	private void OnTriggerEnter(Collider other){

		currentState.OntriggerEnter(other);
	}


}
