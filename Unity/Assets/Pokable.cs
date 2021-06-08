namespace UsingSagoTouch
{
	using System.Collections.Generic;
    using UnityEngine;
    using SagoTouch;
    using Touch = SagoTouch.Touch;

    public class Pokable : MonoBehaviour, ISingleTouchObserver {

        #region Non-Serialized Fields

        [System.NonSerialized]
        private Camera m_Camera;

        [System.NonSerialized]
        private Renderer m_Renderer;

        [System.NonSerialized]
        private Transform m_Transform;

		[System.NonSerialized]
		private List<Touch> m_Touches;

        #endregion

        #region Properties

        private Camera Camera {
            get { return m_Camera = m_Camera ?? CameraUtils.FindRootCamera(this.Transform); }
        }

        private Renderer Renderer {
            get { return m_Renderer = m_Renderer ?? GetComponent<Renderer>(); }
        }

        private Transform Transform {
            get { return m_Transform = m_Transform ?? transform.parent.GetComponent<Transform>(); }
        }

		private List<Touch> Touches {
			get { return m_Touches = m_Touches ?? new List<Touch>(); }
		}

        #endregion

        #region MonoBehaviour

        private void OnEnable() {
            if (TouchDispatcher.Instance) {
                TouchDispatcher.Instance.Add(this);
            }
        }

        private void OnDisable() {
            if (TouchDispatcher.Instance) {
                TouchDispatcher.Instance.Remove(this);
            }
        }

        #endregion

        #region Touch

        public bool OnTouchBegan(Touch touch) {
            if (HitTest(touch)) {
                Debug.Log("Poked");
				Touches.Add(touch);
                return true;
            }
			Debug.Log("Missed");
			return false;
        }

        public void OnTouchMoved(Touch touch) {

        }

        public void OnTouchEnded(Touch touch) {
			Touches.Remove(touch);
        }

        public void OnTouchCancelled(Touch touch) {
			OnTouchEnded(touch);
        }

        private bool HitTest(Touch touch) {
            var bounds = this.Renderer.bounds;
            bounds.extents += Vector3.forward;
            return bounds.Contains(CameraUtils.TouchToWorldPoint(touch, this.Transform, this.Camera));
        }

        #endregion
	}
}
