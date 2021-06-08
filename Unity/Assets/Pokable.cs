namespace UsingSagoTouch
{
    using UnityEngine;
    using SagoTouch;
    using Touch = SagoTouch.Touch;

    public class Pokable : MonoBehaviour, ISingleTouchObserver {

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

        #region ISingleTouchObserver

        public bool OnTouchBegan(Touch touch) {
            Debug.Log("Touched");
            return false;
        }

        public void OnTouchMoved(Touch touch) {

        }

        public void OnTouchEnded(Touch touch) {

        }

        public void OnTouchCancelled(Touch touch) {

        }

        #endregion
    }

}
