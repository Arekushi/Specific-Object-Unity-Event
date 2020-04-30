using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Arekushi.SpecificUnityEvent
{

    public abstract class EventListenerBase<T> : MonoBehaviour
    {

        private readonly Dictionary<GameObject, UnityEventBase<T>> listenerEvent = 
            new Dictionary<GameObject, UnityEventBase<T>>();

        public void RegisterEvent(GameObject ownerEvent, UnityAction<T> action)
        {
            listenerEvent.TryGetValue(ownerEvent, out UnityEventBase<T> unityEvent);

            if (unityEvent == null)
            {
                unityEvent = new UnityEventBase<T>();
                listenerEvent[ownerEvent] = unityEvent;
            } 

            unityEvent.AddListener(action);
        }

        public void UnRegisterEvent(GameObject ownerEvent, UnityAction<T> action)
        {
            if (listenerEvent.TryGetValue(ownerEvent, out UnityEventBase<T> unityEvent))
            {
                if (unityEvent != null) unityEvent.RemoveListener(action);
            }
        }

        public void ExecuteEvent(GameObject ownerEvent, T data) {
            if (listenerEvent.TryGetValue(ownerEvent, out UnityEventBase<T> unityEvent))
            {
                if (unityEvent != null) unityEvent.Invoke(data);
            }
        }

    }
}
