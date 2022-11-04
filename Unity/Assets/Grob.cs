namespace UsingSagoTouch {

	using UnityEngine;
	using SagoTouch;
	using Touch = SagoTouch.Touch;

	public class Grob : MonoBehaviour
	{

		#region Non-Serialized Fields

		[System.NonSerialized]
		private Grabbable m_Grabbable;

		[System.NonSerialized]
		private TouchArea m_TouchArea;

		[System.NonSerialized]
		private TouchAreaObserver m_TouchAreaObserver;

		#endregion

		#region Properties

		private Grabbable Grabbable {
			get { return m_Grabbable = m_Grabbable ?? GetComponent<Grabbable>(); }
		}

		private TouchArea TouchArea {
			get { return m_TouchArea = m_TouchArea ?? GetComponent<TouchArea>(); }
		}

		private TouchAreaObserver TouchAreaObserver {
			get { return m_TouchAreaObserver = m_TouchAreaObserver ?? GetComponent<TouchAreaObserver>(); }
		}

		#endregion

		#region Methods

		private void TouchUp(TouchArea touchArea, Touch touch) {
			this.Grabbable.Grab(this.TouchArea.Camera, touch);
		}

		private void TouchDown(TouchArea touchArea, Touch touch) {
			this.Grabbable.Release(touch);
		}

		#endregion

		#region MonoBehaviour
		
		private void Update() {
			if(this.Grabbable.IsGrabbed) {
				transform.position = this.Grabbable.Position;
			}
		}

		private void OnEnable() {
			this.TouchAreaObserver.TouchUpDelegate = TouchUp;
			this.TouchAreaObserver.TouchDownDelegate = TouchDown;
		}

		private void OnDisable() {
			this.TouchAreaObserver.TouchUpDelegate = null;
			this.TouchAreaObserver.TouchDownDelegate = null;
		}

		#endregion
	}
}