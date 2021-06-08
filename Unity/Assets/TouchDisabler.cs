namespace UsingSagoTouch {

	using UnityEngine;
	using SagoTouch;

		public class TouchDisabler : MonoBehaviour { 
		void Update() {
			if (Input.GetKeyDown("space")) {
				TouchDispatcher.Instance.enabled = !TouchDispatcher.Instance.enabled;
			}
		}
	}
}
