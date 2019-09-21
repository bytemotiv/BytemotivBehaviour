using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Bytemotiv {

    public static class UIExtensions {

        // --- CanvasGroup
        public static void Hide(this CanvasGroup canvas) {
            canvas.alpha = 0.0F;
            canvas.interactable = false;
            canvas.blocksRaycasts = false;
        }

        public static void Show(this CanvasGroup canvas) {
            canvas.alpha = 1.0F;
            canvas.interactable = true;
            canvas.blocksRaycasts = true;
        }

    }

}
