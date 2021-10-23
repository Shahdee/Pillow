using System.Collections.Generic;
using UnityEngine;
using Initialization;
using System;

namespace Helpers
{
    // handles mono updates in one place 
    
    // QA
    // ColorBox: why do we have MonoMediator & MonoRegisterMediator ? 
    // instead of combining it in 1 class 
    // Check: MonoMediator, MonoRegisterMediator
    
    public class MonoMediator : IMonoMediator, IInitializable
    {
        public event Action OnDone;
        
        private HashSet<IUpdatable> _toUpdate;
        private MonoMediatorView _view;
        
        public MonoMediator(List<IUpdatable> toUpdate)
        {
            _toUpdate = new HashSet<IUpdatable>();

            foreach (var updatable in toUpdate)
                _toUpdate.Add(updatable);
        }

        public void Init()
        {
            _view = new GameObject().AddComponent<MonoMediatorView>();
            _view.OnUpdate += PerformUpdate;

            OnDone?.Invoke();
        }

        public void Add(IUpdatable toUpdate)
        {
            if (_toUpdate.Contains(toUpdate))
                return;
            
            _toUpdate.Add(toUpdate);
        }

        private void PerformUpdate(float deltaTime)
        {
            foreach (var updatable in _toUpdate)
                updatable.CustomUpdate(deltaTime);
        }
    }
}