using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WitcherInventory.Entities;

namespace WitcherInventory.Factories
{
    public interface IItemFactory
    {
        Item CreateItem(params object[] parameters);
        string ItemType { get; }
    }
}
