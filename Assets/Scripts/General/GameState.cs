using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private MarbleManager marbleManager;
    [SerializeField] private UpgradeScreen upgradeScreen;
    [SerializeField] private MarbleFlinger flinger;
    public State CurrentState { get; private set; }

    public enum State
    {
        Null,
        Play,
        Upgrade,
        Paused
    }

    public void Initialize()
    {
        SetState(State.Play);
    }

    public void SetState(State state)
    {
        State prevState = CurrentState;
        CurrentState = state;

        if (CurrentState == State.Upgrade) ToUpgradeState();
        if (CurrentState == State.Paused) ToPausedState();
        if (prevState == State.Null && CurrentState == State.Play) NullStateToPlayState();
        if (prevState == State.Upgrade && CurrentState == State.Play) UpgradeStateToPlayState();
    }

    //workaround for use with UnityEvents
    public void SetStateString(string str)
    {
        if (str == "play") SetState(State.Play);
        if (str == "upgrade") SetState(State.Upgrade);
        if (str == "paused") SetState(State.Paused);
    }

    private void NullStateToPlayState()
    {
        marbleManager.SpawnMarble();
    }

    private void ToPausedState()
    {
        flinger.enabled = false;
    }

    private void ToUpgradeState()
    {
        upgradeScreen.SetVisible(true);
        flinger.enabled = false;
    }

    private void UpgradeStateToPlayState()
    {
        upgradeScreen.SetVisible(false);
        flinger.enabled = true;
        marbleManager.SpawnMarble();
    }
}
