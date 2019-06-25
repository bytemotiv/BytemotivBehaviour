using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Bytemotiv.Events {

    // i.e. new Event("blub") {{ "foo", 42 }, { "bar", 123 }}
    // https://stackoverflow.com/questions/1319708/key-value-pairs-in-c-sharp-params


    public class Event : IEnumerable {

        #region vars

        public string eventId;
        public Dictionary<string, object> content;

        #endregion

        // ----------------------------------------------------------------------------------------------------------------

        #region functions 

        public Event(string eventId) {
            this.eventId = eventId;
            content = new Dictionary<string, object>();
        }

        public void put(string key, object value) {
            Add(key, value);
        }

        public void Add(string key, object value) {
            content = content ?? new Dictionary<string, object>();
            content.Add(key, value);
        }

        public string getString(string k, string fallback = "") {
            if (content.ContainsKey(k)) {
                return (string)content[k];
            } else {
                return fallback;
            }
        }

        public int getInt(string k, int fallback = 0) {
            int result = fallback;
            if (content.ContainsKey(k)) {
                result = (int)content[k];
            }
            return result;
        }

        public Vector3 getVector3(string k) {
            Vector3 result = Vector3.zero;
            if (content.ContainsKey(k)) {
                result = (Vector3)content[k];
            }
            return result;
        }

        public bool getBool(string k) {
            bool result = false;
            if (content.ContainsKey(k)) {
                result = (bool)content[k];
            }
            return result;
        }

        public float getFloat(string k, float fallback = 0.0F) {
            float? result = (float)content[k];
            return result ?? fallback;
        }

        public object get(string k) {
            return content[k];
        }

        public void broadcast() {
            EventManager.broadcast(this);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable)content).GetEnumerator();
        }

        #endregion

    }
}
