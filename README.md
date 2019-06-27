BytemotivBehaviour for Unity3D
======
**BytemotivBehaviour** replaces MonoBehaviour in most of my Unity projects.

## Usage

Simply inherit from `BytemotivBehaviour` instead of `MonoBehaviour`

### Event System

Subscribing/Unsubscribing and Handling of an event
```
private void OnEnable() {
    Subscribe("dummy", HandleDummy);
}

private void OnDisable() {
    Unsubscribe("dummy", HandleDummy);
}

private void HandleDummy(Event e) {
    int foo = e.GetInt("foo");
    string bar = e.GetString("bar");
}
```

Fire an event
```
Event e = new Event("dummy") {{ "foo", 123 }, { "bar", "abc" }};
Broadcast(e);
```
