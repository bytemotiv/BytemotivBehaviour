using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Bytemotiv.Events {

    public class EventManager {

        #region vars

        public delegate void EventDelegate(Event e);
        public EventDelegate eventdelegate;
        private static Dictionary<string, EventDelegate> eventHandlers;

        #endregion

        // ---------------------------------------------------------------------------------------

        #region functions

        private static void initEventHandlers() {
            eventHandlers = eventHandlers ?? new Dictionary<string, EventDelegate>();
        }

        public static void subscribe(string eventId, EventDelegate handler) {
            initEventHandlers();
            if (!eventHandlers.ContainsKey(eventId)) {
                eventHandlers.Add(eventId, null);
            }
            eventHandlers[eventId] += handler;
        }

        public static void unsubscribe(string eventId, EventDelegate handler) {
            initEventHandlers();
            if (eventHandlers.ContainsKey(eventId)) {
                eventHandlers[eventId] -= handler;
            }
        }

        public static void broadcast(string eventId) {
            Event e = new Event(eventId);
            broadcast(e);
        }

        public static void broadcast(Event e) {
            if (eventHandlers != null && eventHandlers.ContainsKey(e.eventId)) {
                //try {
                eventHandlers[e.eventId](e);
                //} catch (System.NullReferenceException e) {}
            }
        }

        #endregion
    }
}

namespace Bytemotiv {

    public partial class BytemotivBehaviour {

        internal static Dictionary<string, Events.EventManager.EventDelegate> _handlers;

        public static void subscribe(string eventId, Events.EventManager.EventDelegate handler) {
            Events.EventManager.subscribe(eventId, handler);
        }

        public static void unsubscribe(string eventId, Events.EventManager.EventDelegate handler) {
            Events.EventManager.unsubscribe(eventId, handler);
        }

        public static void broadcast(string eventId) {
            Events.EventManager.broadcast(eventId);
        }

        public static void broadcast(Events.Event e) {
            Events.EventManager.broadcast(e);
        }
    
    }
}
