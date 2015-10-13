using UnityEngine;
using System.Collections;

public class ChaseState : IEnermyState {


	private readonly StatePatternEnermy enermy;
	
	
	public ChaseState(StatePatternEnermy statePatternEnermy){
		enermy=statePatternEnermy;
		
	}
	public void UpdateState(){
		Look();
		Chase();

	}
	public void OntriggerEnter(Collider other){

	}
	public void ToPatrolState(){


	}
	public void ToAlertState(){
		enermy.currentState=enermy.alertState;
	}
	public void ToChaseState(){

		Debug.Log ("Cannot Transition to same state");
	}

	private void Look(){
		RaycastHit hit;
		Vector3 enermyToTarger=(enermy.chaseTarget.position+enermy.offSet)-enermy.eyes.transform.position;
		if(Physics.Raycast(enermy.eyes.transform.position,enermy.eyes.transform.forward,out hit,
		                   enermy.sightRange) && (hit.collider.CompareTag("Player"))){
			
			enermy.chaseTarget=hit.transform;

			
			
		}else{

			ToAlertState();
		}
		
	}

	public void Chase(){
		enermy.meshRndererFlag.material.color=Color.red;
		enermy.navMeshAgent.destination=enermy.chaseTarget.position;
		enermy.navMeshAgent.Resume();

	}

}
