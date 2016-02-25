using UnityEngine;
using System.Collections;

public class AlertState : IEnermyState {


	private readonly StatePatternEnermy enermy;
	private float searchTimer;
	
	public AlertState(StatePatternEnermy statePatternEnermy){
		enermy=statePatternEnermy;
		
	}

	public void UpdateState(){
		Look ();
		Search();
	}
	public void OntriggerEnter(Collider other){

	}
	public void ToPatrolState(){
		enermy.currentState=enermy.patrolState;
		searchTimer=0;

	}
	public void ToAlertState(){
		Debug.Log ("Cannot Transition to same state");
	}
	public void ToChaseState(){
		enermy.currentState=enermy.chaseState;
		searchTimer=0;
		
	}
	private void Look(){
		RaycastHit hit;
		if(Physics.Raycast(enermy.eyes.transform.position,enermy.eyes.transform.forward,out hit,
		                   enermy.sightRange) && (hit.collider.CompareTag("Player"))){
			
			enermy.chaseTarget=hit.transform;
			ToChaseState();
			
			
		}
		
	}
	private void Search(){
		enermy.meshRndererFlag.material.color=Color.yellow;
		enermy.navMeshAgent.Stop();
		enermy.transform.Rotate(0,enermy.searchingTurnSpeed*Time.deltaTime,0);

		searchTimer+=Time.deltaTime;

		if(searchTimer>=enermy.searchingDuration){
			ToPatrolState();

		}

	}
}
