using UnityEngine;
using System.Collections;

public class PatrolState : IEnermyState {



	private readonly StatePatternEnermy enermy;
	private int nextWayPoint;

	public PatrolState(StatePatternEnermy statePatternEnermy){
		enermy=statePatternEnermy;

	}

	public void UpdateState(){
		Look ();
		Patrol();
	}
	public void OntriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Player")){
			ToAlertState();

		}
	}
	public void ToPatrolState(){
		Debug.Log ("Cannot Transition to same state");

	}
	public void ToAlertState(){
		enermy.currentState=enermy.alertState;
	}
	public void ToChaseState(){
		enermy.currentState=enermy.chaseState;

	}

	private void Look(){
		RaycastHit hit;
		if(Physics.Raycast(enermy.eyes.transform.position,enermy.eyes.transform.forward,out hit,
		                   enermy.sightRange) && (hit.collider.CompareTag("Player"))){

			enermy.chaseTarget=hit.transform;
			ToChaseState();


		}

	}

	void Patrol(){

		enermy.meshRndererFlag.material.color=Color.green;
		enermy.navMeshAgent.destination=enermy.wayPoints[nextWayPoint].position;
		enermy.navMeshAgent.Resume();

		if(enermy.navMeshAgent.remainingDistance<=enermy.navMeshAgent.stoppingDistance 
		  && enermy.navMeshAgent.pathPending){

			nextWayPoint=(nextWayPoint+1)%enermy.wayPoints.Length;

		}
	}
}
