using System.Collections.Generic;
using System;
using UnityEngine;

namespace Initialization
{
    public class InitializeMediator : IInitializeMediator, Zenject.IInitializable, IDisposable  
    {
        public event Action OnDone;

        private readonly List<IInitializable> _initializables;

        private int _waitingCount;

        public InitializeMediator(List<IInitializable> initializables)
        {
            _initializables = initializables;
            
            foreach (var init in _initializables)
                init.OnDone += InitDone;
        }

        public void Initialize()
        {
            _waitingCount = _initializables.Count;
            
            foreach (var toInit in _initializables)
                toInit.Init();
        }
        
        private void InitDone()
        {
            _waitingCount--;

            if (_waitingCount == 0)
                OnDone?.Invoke();
        }
        
        public void Dispose()
        {
            foreach (var init in _initializables)
                init.OnDone -= InitDone;
        }
    }
}