using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Sirenix.OdinInspector;

public class SkillTreeNodeUI : MonoBehaviour, IPointerClickHandler
{
    [HideInInspector] public SkillTreeNodeSO nodeSO;
    public SkillTreeNodeUI parent;
    private State state;
    public UnityEvent OnLocked;
    public UnityEvent OnUnlocked;
    public UnityEvent OnPurchased;
    public event System.Action<SkillTreeNodeUI> OnClick;

    public enum State
    {
        Hidden, //not visible
        Locked, //visible, but can't be purchased
        Unlocked, //visible and can be purchased
        Purchased //visible and already purchased
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (state != State.Unlocked) return;

        OnClick?.Invoke(this);
    }

    public void SetState(State state)
    {
        this.state = state;
        if (this.state == State.Unlocked) OnUnlocked?.Invoke();
        if (this.state == State.Locked) OnLocked?.Invoke();
        if (this.state == State.Purchased) OnPurchased?.Invoke();
    }
}
