using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WitcherInventory.Entities;

namespace WitcherInventory.Factories
{
    public class ItemFactoryRegistry
    {
        private Dictionary<string, IItemFactory> _factories = new Dictionary<string, IItemFactory>();

        public void RegisterFactory(IItemFactory factory)
        {
            _factories[factory.ItemType] = factory;
        }

        public Item CreateItem(string type, params object[] parameters)
        {
            if (_factories.ContainsKey(type))
            {
                return _factories[type].CreateItem(parameters);
            }
            throw new ArgumentException($"Unknown item type: {type}");
        }
    }
}