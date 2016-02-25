using UnityEngine;
using System.Collections;

public interface IEnermyState {

	void UpdateState();
	void OntriggerEnter(Collider other);
	void ToPatrolState();
	void ToAlertState();
	void ToChaseState();
}
