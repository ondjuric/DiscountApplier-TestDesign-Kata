using DiscountApplier;
using Moq;
using Assert = Xunit.Assert;

namespace TestDiscountApplier;

public class DiscountApplierXUnitTest
{
	[Fact]
	public void TestApplyV1()
	{
		// TODO: trigger the bug in DiscountApplier.ApplyV1() by implementing the Notifier interface
		// arrange
		const double discount = 2.5;
		var expectedMessage = $"You've got a discount of {discount}";
        
		var notifierMock = new Mock<INotifier>();

		var user1 = new User("user1", "user1@us.us");
		var user2 = new User("user2", "user2@us.us");
		var user3 = new User("user3", "user3@us.us");
		List<User> users = new List<User>{user1, user2};

		var discountApplier = new DiscountApplier.DiscountApplier(notifierMock.Object);

		// act
		discountApplier.ApplyV1(discount, users);
        
		// assert
		notifierMock.Verify(n => n.Notify(user1, expectedMessage), Times.Once);
		notifierMock.Verify(n => n.Notify(user2, expectedMessage), Times.Once);
		notifierMock.Verify(n => n.Notify(user3, expectedMessage), Times.Never);
	}

	[Fact]
	public void TestApplyV2()
	{
		// TODO: trigger the bug in DiscountApplier.ApplyV2() by implementing the Notifier interface
	}
}