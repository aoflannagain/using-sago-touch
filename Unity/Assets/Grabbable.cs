namespace UsingSagoTouch {
	
	using UnityEngine;
	using Touch = SagoTouch.Touch;

	public class Grabbable : MonoBehaviour {


		#region Events

		public event System.Action<Grabbable, Touch> OnGrab;
		public event System.Action<Grabbable, Touch> OnRelease;

		#endregion


		#region Methods

		public void Grab(Camera camera, Touch touch) {
			if (isActiveAndEnabled) {
				this.Camera = camera;
				this.Touch = touch;
				this.GrabOffset = this.TouchPosition - this.Position;
				NotifyGrab(touch);
			}
		}

		public void Release(Touch touch) {
			if (this.IsGrabbed && this.Touch == touch) {
				this.Camera = null;
				this.Touch = null;
				this.GrabOffset = Vector2.zero;
				NotifyRelease(touch);
			}
		}

		#endregion


		#region Properties

		public Camera Camera {
			get;
			private set;
		}

		public bool IsGrabbed {
			get { return this.Camera && this.Touch != null; }
		}

		public Vector2 GrabOffset {
			get { return this.Transform.TransformVector(this.LocalGrabOffset); }
			set { this.LocalGrabOffset = this.Transform.InverseTransformVector(value); }
		}

		public Vector2 LocalGrabOffset {
			get;
			set;
		}

		public Touch Touch {
			get;
			private set;
		}

		public Vector2 TouchPosition {
			get { return this.IsGrabbed ? (Vector2)this.Camera.ScreenToWorldPoint(this.Touch.Position) : this.Position; }
		}

		public Vector2 Position {
			get { return this.Transform.position; }
		}

		public Transform Transform {
			get {
				if (!m_Transform) {
					m_Transform = transform;
				}
				return m_Transform;
			}
		}

		#endregion


		#region Serialized Fields

		[SerializeField]
		private Transform m_Transform;

		#endregion


		#region MonoBehaviour

		private void OnDisable() {
			Release(this.Touch);
		}

		#endregion


		#region Internal Methods

		private void NotifyGrab(Touch touch) {
			if (this.OnGrab != null) {
				this.OnGrab(this, touch);
			}
		}

		private void NotifyRelease(Touch touch) {
			if (this.OnRelease != null) {
				this.OnRelease(this, touch);
			}
		}

		#endregion


	}

}
