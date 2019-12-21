using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public abstract class SceneView
{
    public abstract void InitView(EventCallback0 eventCallback0);

    public GamePanel panel;

    TypingEffect typingEffect;
    public EventCallback0 eventCallback0;

    public void PlayTypeEffect(GTextField text)
    {
        typingEffect = new TypingEffect(text);
        typingEffect.Start();
        Timers.inst.Add(0.020f, 0, PrintText);
    }

    void PrintText(object param)
    {
        if (!typingEffect.Print())
        {
            Timers.inst.Remove(PrintText);
        }
    }

    public virtual void Dispose()
    {
        if (typingEffect != null)
        {
            Timers.inst.Remove(PrintText);
        }
        panel.Dispose();

        eventCallback0?.Invoke();
    }
}
