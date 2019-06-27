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

        private static void InitEventHandlers() {
            eventHandlers = eventHandlers ?? new Dictionary<string, EventDelegate>();
        }

        public static void Subscribe(string eventId, EventDelegate handler) {
            InitEventHandlers();
            if (!eventHandlers.ContainsKey(eventId)) {
                eventHandlers.Add(eventId, null);
            }
            eventHandlers[eventId] += handler;
        }

        public static void Unsubscribe(string eventId, EventDelegate handler) {
            InitEventHandlers();
            if (eventHandlers.ContainsKey(eventId)) {
                eventHandlers[eventId] -= handler;
            }
        }

        public static void Broadcast(string eventId) {
            Event e = new Event(eventId);
            Broadcast(e);
        }

        public static void Broadcast(Event e) {
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

        public static void Subscribe(string eventId, Events.EventManager.EventDelegate handler) {
            Events.EventManager.Subscribe(eventId, handler);
        }

        public static void Unsubscribe(string eventId, Events.EventManager.EventDelegate handler) {
            Events.EventManager.Unsubscribe(eventId, handler);
        }

        public static void Broadcast(string eventId) {
            Events.EventManager.Broadcast(eventId);
        }

        public static void Broadcast(Events.Event e) {
            Events.EventManager.Broadcast(e);
        }
    
    }
}
