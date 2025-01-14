﻿using Doug.Models;
using Doug.Repositories;

namespace Doug.Items
{
    public abstract class ConsumableItem : Item
    {
        private readonly IInventoryRepository _inventoryRepository;

        protected ConsumableItem(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
            MaxStack = 99;
        }

        public override string Use(int itemPos, User user, string channel)
        {
            _inventoryRepository.RemoveItem(user, itemPos);
            return DougMessages.ConsumedItem;
        }
    }
}
