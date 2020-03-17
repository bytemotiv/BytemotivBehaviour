using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Bytemotiv.Messaging {

    public class MessageManager {

        #region vars

        public delegate void MessageDelegate(Message message);
        public MessageDelegate messagedelegate;
        private static Dictionary<string, MessageDelegate> messageHandlers;

        #endregion

        // ---------------------------------------------------------------------------------------

        #region functions

        private static void InitMessageHandlers() {
            messageHandlers = messageHandlers ?? new Dictionary<string, MessageDelegate>();
        }

        public static void Subscribe(string messageId, MessageDelegate handler) {
            InitMessageHandlers();
            if (!messageHandlers.ContainsKey(messageId)) {
                messageHandlers.Add(messageId, null);
            }
            messageHandlers[messageId] += handler;
        }

        public static void Unsubscribe(string messageId, MessageDelegate handler) {
            InitMessageHandlers();
            if (messageHandlers.ContainsKey(messageId)) {
                messageHandlers[messageId] -= handler;
            }
        }

        public static void Broadcast(string messageId) {
            Message e = new Message(messageId);
            Broadcast(e);
        }

        public static void Broadcast(Message e) {
            if (messageHandlers != null && messageHandlers.ContainsKey(e.messageId)) {
                //try {
                messageHandlers[e.messageId](e);
                //} catch (System.NullReferenceException e) {}
            }
        }

        #endregion
    }
}

namespace Bytemotiv {

    public partial class BytemotivBehaviour {

        internal static Dictionary<string, Messaging.MessageManager.MessageDelegate> _handlers;

        public static void Subscribe(string messageId, Messaging.MessageManager.MessageDelegate handler) {
            Messaging.MessageManager.Subscribe(messageId, handler);
        }

        public static void Unsubscribe(string messageId, Messaging.MessageManager.MessageDelegate handler) {
            Messaging.MessageManager.Unsubscribe(messageId, handler);
        }

        public static void Broadcast(string messageId) {
            Messaging.MessageManager.Broadcast(messageId);
        }

        public static void Broadcast(Messaging.Message e) {
            Messaging.MessageManager.Broadcast(e);
        }

    }
}
