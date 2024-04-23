using Application.Commands;
using DataAccess.Repositories;
using FluentAssertions;
using FluentResults;
using Moq;

namespace Application.Tests;

public class ActivateMembershipCommandTests
{
    [Test]
    public async Task When_CalledWithCorrectParams_ShouldReturnExecutionResult()
    {
        var result = await _sut.Execute(new ActivateMembershipCommandArgs(_customerId));

        result.IsSuccess.Should().Be(true);
    }
        
    [Test]
    public async Task When_CalledWithCorrectParams_ShouldExecuteAddPurchase()
    {
        await _sut.Execute(new ActivateMembershipCommandArgs(_customerId));

        _customerRepositoryMock.Verify(mock => mock.ActivateCustomer(It.IsAny<int>()), Times.Once());
    }
        
    [SetUp]
    public void Setup()
    {
        _customerRepositoryMock = new Mock<ICustomerRepository>();
        _customerRepositoryMock.Setup(x => x.ActivateCustomer(It.IsAny<int>()))
            .Returns(Task.FromResult(Result.Ok()));
        _sut = new ActivateMembershipCommand(_customerRepositoryMock.Object);
    }

    private const int _customerId = 123;
    private ActivateMembershipCommand _sut;
    private Mock<ICustomerRepository> _customerRepositoryMock;
}