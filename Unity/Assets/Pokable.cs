namespace UsingSagoTouch
{
    using UnityEngine;
    using SagoTouch;
    using Touch = SagoTouch.Touch;

    public class Pokable : MonoBehaviour, ISingleTouchObserver {

        public bool OnTouchBegan(Touch touch) {
            return false;
        }

        public void OnTouchMoved(Touch touch) {

        }

        public void OnTouchEnded(Touch touch) {

        }

        public void OnTouchCancelled(Touch touch) {

        }

    }

}
