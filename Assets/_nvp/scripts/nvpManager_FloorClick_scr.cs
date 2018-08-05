using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using newvisionsproject.managers.events;

namespace newvisionsproject.example_unity_0002_nav_mesh 
{

	public class nvpManager_FloorClick_scr : MonoBehaviour 
	{
		// +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		[SerializeField] private Vector3 _clickPosition;
		[SerializeField] private GameObject _floor;
		private LayerMask _floorMask;



		// +++ callbacks ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		void Start () {
			_floorMask = LayerMask.GetMask("nvpFloor");
		}
		
		void Update () {
			if(Input.GetMouseButtonUp(0)){
				var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if(Physics.Raycast(ray, out hit, 100, _floorMask))
				{
					_clickPosition = hit.point;
					nvpManager_Events_scr.INSTANCE.InvokeEvent(GameEvents.OnFloorPositionSelected, this, _clickPosition);
				}
			}
		}
	}

}
