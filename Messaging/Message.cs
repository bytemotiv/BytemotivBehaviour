using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Bytemotiv.Messaging {

    // i.e. new Message("blub") {{ "foo", 42 }, { "bar", 123 }}
    // https://stackoverflow.com/questions/1319708/key-value-pairs-in-c-sharp-params


    public class Message : IEnumerable {

        #region vars

        public string messageId;
        public Dictionary<string, object> content;

        #endregion

        // ----------------------------------------------------------------------------------------------------------------

        #region functions

        public Message(string messageId) {
            this.messageId = messageId;
            content = new Dictionary<string, object>();
        }

        public void Put(string key, object value) {
            Add(key, value);
        }

        public void Add(string key, object value) {
            content = content ?? new Dictionary<string, object>();
            content.Add(key, value);
        }

        public string GetString(string k, string fallback = "") {
            if (content.ContainsKey(k)) {
                return (string)content[k];
            } else {
                return fallback;
            }
        }

        public int GetInt(string k, int fallback = 0) {
            int result = fallback;
            if (content.ContainsKey(k)) {
                result = (int)content[k];
            }
            return result;
        }

        public Vector3 GetVector3(string k) {
            Vector3 result = Vector3.zero;
            if (content.ContainsKey(k)) {
                result = (Vector3)content[k];
            }
            return result;
        }

        public bool GetBool(string k) {
            bool result = false;
            if (content.ContainsKey(k)) {
                result = (bool)content[k];
            }
            return result;
        }

        public float GetFloat(string k, float fallback = 0.0F) {
            float? result = (float)content[k];
            return result ?? fallback;
        }

        public object Get(string k) {
            return content[k];
        }

        public void Broadcast() {
            EventManager.Broadcast(this);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable)content).GetEnumerator();
        }

        #endregion

    }
}
