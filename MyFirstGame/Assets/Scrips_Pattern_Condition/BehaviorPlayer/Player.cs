using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlyMan;

public class Player : MonoBehaviour
{
    private Dictionary<Type, IPlayerBehavior> behaviorsMap;
    private IPlayerBehavior behaviorCurrent;

    private void Start()
    {
        this.InitBehavior();
        this.SetBehaviorByDefaulte();
    }

    private void InitBehavior()
    {
        this.behaviorsMap = new Dictionary<Type, IPlayerBehavior>();

        this.behaviorsMap[typeof(IPlayerBehaviorCarStanding)] = new IPlayerBehaviorCarStanding();
        this.behaviorsMap[typeof(IPlayerBehaviorCarRides)] = new IPlayerBehaviorCarRides();
        this.behaviorsMap[typeof(IPlayerBehaviorManFlies)] = new IPlayerBehaviorManFlies();
        this.behaviorsMap[typeof(IPlayerBehaviorManHasStopped)] = new IPlayerBehaviorManHasStopped();
    }

    private void SetBehavior(IPlayerBehavior newBehavior)
    {
        if (this.behaviorCurrent != null)
            this.behaviorCurrent.Exit();

        this.behaviorCurrent = newBehavior;
        this.behaviorCurrent.Enter();
    }

    private void SetBehaviorByDefaulte()
    {
        this.SetBehaviorCarStanding();
    }

    private IPlayerBehavior GetBehavior<T>() where T : IPlayerBehavior
    {
        var type = typeof(T);
        return this.behaviorsMap[type];
    }

    private void Update()
    {
        if (this.behaviorCurrent != null)
            this.behaviorCurrent.Update();
    }

    public void SetBehaviorCarStanding()
    {
        if (behaviorCurrent == null! ||
            behaviorCurrent == behaviorsMap[typeof(IPlayerBehaviorManHasStopped)])
        {
            var behavior = this.GetBehavior<IPlayerBehaviorCarStanding>();
            this.SetBehavior(behavior);
        }
        else Debug.Log($"Error! Transition from {behaviorCurrent} to BehaviorCarStanding");
    }

    public void SetBehaviorCarRides()
    {
        if (behaviorCurrent == behaviorsMap[typeof(IPlayerBehaviorCarStanding)])
        {
            var behavior = this.GetBehavior<IPlayerBehaviorCarRides>();
        this.SetBehavior(behavior);
        }
        else Debug.Log($"Error! Transition from {behaviorCurrent} to BehaviorManHasStopped");
    }

    public void SetBehaviorManFlies()
    {
        if (behaviorCurrent == behaviorsMap[typeof(IPlayerBehaviorCarRides)])
        {
            var behavior = this.GetBehavior<IPlayerBehaviorManFlies>();
        this.SetBehavior(behavior);
        }
        else Debug.Log($"Error! Transition from {behaviorCurrent} to BehaviorManFlies");
    }

    public void SetBehaviorManStopped()
    {
        if (behaviorCurrent == behaviorsMap[typeof(IPlayerBehaviorManFlies)])
        {
            var behavior = this.GetBehavior<IPlayerBehaviorManHasStopped>();
            this.SetBehavior(behavior);
        }
        else Debug.Log($"Error! Transition from {behaviorCurrent} to BehaviorCarStanding");
    }
}
