using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Notification", menuName = "Notification")]
public class NotificationScriptableObject : ScriptableObject {
    // actions
    [SerializeField] UnityEvent _unityEvent = new();
    private Action<string> _action = null;

    public void SetAction(Action<string> action) {
        _action = action; 
    }
    
    public void InvokeNotification(string message) {
        // invoke unity events if there are any
        if (_unityEvent.GetPersistentEventCount() > 0) 
            _unityEvent.Invoke();

        // invoke the other delegate
        _action?.Invoke(message);
    }
}
