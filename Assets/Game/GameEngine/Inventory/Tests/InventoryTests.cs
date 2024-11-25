using System.Linq;
using NUnit.Framework;

namespace Game.GameEngine.Inventory
{
    public class InventoryTests
    {
        [Test]
        public void WhenAddItem_ShouldBe1SlotWithItem()
        {
            var inventory = new Inventory();
            var item = new InventoryItem("TestItem1", InventoryItemFlags.NONE, null, null);
            
            inventory.Add(item);
            
            Assert.True(inventory.Slots.Count(s => s.Id == item.Id) == 1);
        }

        [Test]
        public void WhenAdd2StackItems_ShouldBe1SlotWith2Items()
        {
            var inventory = new Inventory();
            var item = new InventoryItem("TestItem1", InventoryItemFlags.STACKABLE, null, null);
            
            inventory.Add(item);
            inventory.Add(item);
            
            Assert.True(inventory.Slots.Count == 1 && inventory.Slots.First().Id == item.Id && inventory.Slots.First().Count == 2);
        }

        [Test]
        public void WhenRemoveFromEmptyInventory_ShouldBeFalse()
        {
            var inventory = new Inventory();
            var item = new InventoryItem("TestItem1", InventoryItemFlags.STACKABLE, null, null);
            
            Assert.False(inventory.TryRemove(item));
        }

        [Test]
        public void WhenRemoveTooManyItems_ShouldBeFalse()
        {
            var inventory = new Inventory();
            var item = new InventoryItem("TestItem1", InventoryItemFlags.STACKABLE, null, null);
            
            inventory.Add(item);
            
            Assert.False(inventory.TryRemove(item, 2));
        }

        [Test]
        public void WhenRemoveNormalCount_ShouldBeRemoved()
        {
            var inventory = new Inventory();
            var item = new InventoryItem("TestItem1", InventoryItemFlags.STACKABLE, null, null);
            
            inventory.Add(item);
            inventory.Add(item);
            
            Assert.True(inventory.TryRemove(item, 2));
            Assert.True(inventory.GetCount(item) == 0);
            Assert.False(inventory.Contains(item));
        }

        [Test]
        public void WhenAdd2StackItems_ShouldBe2SlotWith2Items()
        {
            var inventory = new Inventory();
            var item = new InventoryItem("TestItem1", InventoryItemFlags.NONE, null, null);
            
            inventory.Add(item);
            inventory.Add(item);
            
            Assert.True(inventory.Slots.Count == 2);
            Assert.True(inventory.Slots.Count(s => s.Id == item.Id) == 2);
        }

        [Test]
        public void WhenAddDifferentItems_ShouldPreciseCountAllOfThem()
        {
            var inventory = new Inventory();
            var item1 = new InventoryItem("TestItem1", InventoryItemFlags.NONE, null, null);
            var item2 = new InventoryItem("TestItem2", InventoryItemFlags.STACKABLE, null, null);
            var item3 = new InventoryItem("TestItem3", InventoryItemFlags.STACKABLE, null, null);
            var item4 = new InventoryItem("TestItem4", InventoryItemFlags.CONSUMABLE, null, null);
            
            inventory.Add(item1);
            inventory.Add(item2, 3);
            inventory.Add(item1);
            inventory.Add(item4);
            inventory.Add(item3);
            inventory.Add(item3);
            
            Assert.True(inventory.GetCount(item1) == 2);
            Assert.True(inventory.GetCount(item2) == 3);
            Assert.True(inventory.GetCount(item3) == 2);
            Assert.True(inventory.GetCount(item4) == 1);
            Assert.True(inventory.Slots.Count == 5);
        }
    }
}