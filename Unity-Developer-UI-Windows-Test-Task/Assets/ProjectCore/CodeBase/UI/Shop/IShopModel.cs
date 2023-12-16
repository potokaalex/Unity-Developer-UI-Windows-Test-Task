using System.Collections.Generic;
using CodeBase.Common.Data;

namespace CodeBase.UI.Shop
{
    public interface IShopModel
    {
        public EventField<List<string>> BoughtItemsIDs { get; }
        public EventField<int> CompletedLevelNumber { get; }
        public EventField<int> TicketsCount { get; }
    }
}