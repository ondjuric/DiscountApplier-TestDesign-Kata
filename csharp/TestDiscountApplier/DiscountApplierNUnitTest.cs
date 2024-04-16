using DiscountApplier;
using Assert = NUnit.Framework.Assert;

namespace TestDiscountApplier;

[TestFixture]
public class DiscountApplierNUnitTest
{
    [Test]
    public void TestApplyV1()
    {
        // arrange
        var notifier = new DoubleNotifier();
        var user1 = new User("user1", "user1@gmail.com");
        var users = new List<User> { user1 };
        var discountApplier = new DiscountApplier.DiscountApplier(notifier);
        
        // act
        discountApplier.ApplyV1(2.0, users);

        // assert
        Assert.That(notifier.NotifiedUsers[0], Is.EqualTo(user1));
    }

    [Test]
    public void TestApplyV2()
    {
        // TODO: trigger the bug in DiscountApplier.ApplyV2() by implementing the Notifier interface
        // arrange
        var notifier = new DoubleNotifier();
        var user1 = new User("user1", "user1@gmail.com");
        var user2 = new User("user2", "user2@gmail.com");
        var users = new List<User> {user1, user2};
        var discountApplier = new DiscountApplier.DiscountApplier(notifier);
        
        // act
        discountApplier.ApplyV2(2.0, users);

        // assert
        Assert.That(users, Is.EqualTo(notifier.NotifiedUsers));
        //Assert.That(notifier.NotifiedUsers, Does.Contain(user2));
    }
    
    // dubler
    private class DoubleNotifier : INotifier
    {
        public readonly List<User> NotifiedUsers = new();
        public void Notify(User user, string message)
        {
            NotifiedUsers.Add(user);
        }
    }
}

