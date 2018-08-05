using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using newvisionsproject.managers.events;

namespace newvisionsproject.example_unity_0002_nav_mesh 
{
	public class nvpManager_Player_scr : MonoBehaviour 
	{
		// +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


		// +++ unity callbacks ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		void Start () {
			nvpManager_Events_scr.INSTANCE.SubscribeToEvent(GameEvents.OnFloorPositionSelected, OnFloorPositionSelected);	
		}
		
		void Update () {
			
		}




		// +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		void OnFloorPositionSelected(object s, object e){
			Vector3 pos = (Vector3)e;
			this.transform.position = pos; 
		}

		void OnDestroy(){
			nvpManager_Events_scr.INSTANCE.UnsubscribeFromEvent(GameEvents.OnFloorPositionSelected, OnFloorPositionSelected);
		}
	}
}
