using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlyMan.Behavior;

public class Player : MonoBehaviour
{
    private Dictionary<Type, IPlayerBehavior> _behaviorsMap;
    private IPlayerBehavior _behaviorCurrent;

    private void Start()
    {
        this.InitBehavior();
        this.SetBehaviorByDefaulte();
    }

    private void InitBehavior()
    {
        this._behaviorsMap = new Dictionary<Type, IPlayerBehavior>();

        this._behaviorsMap[typeof(IPlayerBehaviorCarStanding)] = new IPlayerBehaviorCarStanding();
        this._behaviorsMap[typeof(IPlayerBehaviorCarRides)] = new IPlayerBehaviorCarRides();
        this._behaviorsMap[typeof(IPlayerBehaviorManFlies)] = new IPlayerBehaviorManFlies();
        this._behaviorsMap[typeof(IPlayerBehaviorManHasStopped)] = new IPlayerBehaviorManHasStopped();
    }

    private void SetBehavior(IPlayerBehavior newBehavior)
    {
        if (this._behaviorCurrent != null)
            this._behaviorCurrent.Exit();

        this._behaviorCurrent = newBehavior;
        this._behaviorCurrent.Enter();
    }

    private void SetBehaviorByDefaulte()
    {
        this.SetBehaviorCarStanding();
    }

    private IPlayerBehavior GetBehavior<T>() where T : IPlayerBehavior
    {
        var type = typeof(T);
        return this._behaviorsMap[type];
    }

    private void Update()
    {
        if (this._behaviorCurrent != null)
            this._behaviorCurrent.Update();
    }

    public void SetBehaviorCarStanding()
    {
        var behavior = this.GetBehavior<IPlayerBehaviorCarStanding>();
        this.SetBehavior(behavior);
    }

    public void SetBehaviorCarRides()
    {
         var behavior = this.GetBehavior<IPlayerBehaviorCarRides>();
         this.SetBehavior(behavior);
    }

    public void SetBehaviorManFlies()
    {
        var behavior = this.GetBehavior<IPlayerBehaviorManFlies>();
        this.SetBehavior(behavior);
    }

    public void SetBehaviorManStopped()
    {
        var behavior = this.GetBehavior<IPlayerBehaviorManHasStopped>();
        this.SetBehavior(behavior);
    }
}
