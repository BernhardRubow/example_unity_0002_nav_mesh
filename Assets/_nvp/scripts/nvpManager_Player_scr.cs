using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using newvisionsproject.managers.events;

namespace newvisionsproject.example_unity_0002_nav_mesh 
{
	public class nvpManager_Player_scr : MonoBehaviour 
	{
		// +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		NavMeshAgent _navAgent;

		// +++ unity callbacks ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		void Start () {
			
			_navAgent = this.GetComponent<NavMeshAgent>();

			nvpManager_Events_scr.INSTANCE.SubscribeToEvent(GameEvents.OnFloorPositionSelected, OnFloorPositionSelected);	
		}
		
		void Update () {
			
		}




		// +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		void OnFloorPositionSelected(object s, object e){
			Vector3 pos = (Vector3)e;
			_navAgent.SetDestination(pos);
		}

		void OnDestroy(){
			nvpManager_Events_scr.INSTANCE.UnsubscribeFromEvent(GameEvents.OnFloorPositionSelected, OnFloorPositionSelected);
		}
	}
}
