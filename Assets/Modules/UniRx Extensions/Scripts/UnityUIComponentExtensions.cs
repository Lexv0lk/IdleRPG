using System;
using TMPro;
using UniRx;

namespace Modules.UniRxExtensions
{
    public static partial class UnityUIComponentExtensions
    {
        public static IDisposable SubscribeToTextTMP(this IObservable<string> source, TMP_Text text)
        {
            return source.SubscribeWithState(text, (x, t) => t.text = x);
        }
    }
}