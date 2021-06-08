namespace UsingSagoTouch{
	using UnityEngine;
	using SagoTouch;
	using Touch = SagoTouch.Touch;

	public class Touchable : MonoBehaviour
	{
		#region Non-Serialized Fields

		[System.NonSerialized]
		private TouchArea m_TouchArea;

		[System.NonSerialized]
		private TouchAreaObserver m_TouchAreaObserver;

		#endregion

		#region Properties

		private TouchArea TouchArea {
			get { return m_TouchArea = m_TouchArea ?? GetComponent<TouchArea>(); }
		}

		private TouchAreaObserver TouchAreaObserver {
			get { return m_TouchAreaObserver = m_TouchAreaObserver ?? GetComponent<TouchAreaObserver>(); }
		}

		#endregion

		#region MonoBehaviour

		private void OnEnable() {
			this.TouchAreaObserver.TouchUpDelegate = TouchUp;
			this.TouchAreaObserver.TouchDownDelegate = TouchDown;
		}

		private void OnDisable() {
			this.TouchAreaObserver.TouchUpDelegate = null;
			this.TouchAreaObserver.TouchDownDelegate = null;
		}

		#endregion

		#region Methods

		private void TouchUp(TouchArea touchArea, Touch touch) {
			Debug.Log("Touch Up!", this);
		}
		private void TouchDown(TouchArea touchArea, Touch touch) {
			transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
		}


		#endregion

	}
}
