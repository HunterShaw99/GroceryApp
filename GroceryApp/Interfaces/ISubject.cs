using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryApp.Interfaces
{
    public interface ISubject
    {
        public void RegisterObserver(IObserver o);
        public void RemoveObserver(IObserver o);
        public void NotifyObservers();
    }
}
