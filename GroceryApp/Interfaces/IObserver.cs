using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryApp.Interfaces
{
    public interface IObserver
    {
        public void Update(List<Models.GroceryItem> value);
    }
}
