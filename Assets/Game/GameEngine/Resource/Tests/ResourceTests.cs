using NUnit.Framework;

namespace Game.GameEngine.Resource.Tests
{
    public class ResourceTests
    {
        [Test]
        public void WhenNoResource_ShouldBeException()
        {
            var storage = new ResourcesStorage();

            Assert.Catch(() => storage.Remove(ResourceType.MONEY, 1));
        }
        
        [Test]
        public void WhenNoResource_ShouldBeCount0()
        {
            var storage = new ResourcesStorage();

            Assert.True(storage.GetCount(ResourceType.MONEY) == 0);
        }
        
        [Test]
        public void WhenNoResource_ContainsShouldBeFalse()
        {
            var storage = new ResourcesStorage();

            Assert.False(storage.Contains(ResourceType.MONEY));
        }
        
        [Test]
        public void WhenAddResources_CountShouldBePrecise()
        {
            var storage = new ResourcesStorage();
            
            storage.Add(ResourceType.MONEY, 555);

            Assert.True(storage.GetCount(ResourceType.MONEY) == 555);
        }

        [Test]
        public void WhenRemovingAfterAdding_ShouldBeZeroResources()
        {
            var storage = new ResourcesStorage();
            
            storage.Add(ResourceType.MONEY, 555);
            storage.Remove(ResourceType.MONEY, 555);

            Assert.True(storage.GetCount(ResourceType.MONEY) == 0);
        }
        
        [Test]
        public void WhenTryRemovingAfterAdding_ShouldBePreciseCountOfResourcesAndTrueResult()
        {
            var storage = new ResourcesStorage();
            
            storage.Add(ResourceType.MONEY, 555);

            var result = storage.TryRemove(ResourceType.MONEY, 550);
            Assert.True(result);
            Assert.True(storage.GetCount(ResourceType.MONEY) == 5);
        }
        
        [Test]
        public void WhenTryRemovingMoreThanAdded_ShouldBeFalseResultAndAddedValueLeft()
        {
            var storage = new ResourcesStorage();
            
            storage.Add(ResourceType.MONEY, 555);

            var result = storage.TryRemove(ResourceType.MONEY, 1000);
            Assert.False(result);
            Assert.True(storage.GetCount(ResourceType.MONEY) == 555);
        }
    }
}