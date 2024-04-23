using Application.Commands;
using Contracts;
using DataAccess.Models;
using DataAccess.Repositories;
using FluentAssertions;
using FluentResults;
using Moq;

namespace Application.Tests;

public class GenerateShippingSlipCommandTests
{
    [Test]
    public async Task When_CalledWithCorrectParams_ShouldReturnExecutionResult()
    {
        var result = await _sut.Execute(new GenerateShippingSlipCommandArgs(new PurchaseOrder(), new Customer()));

        result.IsSuccess.Should().Be(true);
    }
        
    [Test]
    public async Task When_CalledWithCorrectParams_ShouldExecuteAddPurchase()
    {
        await _sut.Execute(new GenerateShippingSlipCommandArgs(new PurchaseOrder(), new Customer()));

        _shippingSlipRepositoryMock.Verify(mock => mock.GenerateShippingSlip(It.IsAny<ShippingSlipRow>()), Times.Once());
    }
        
    [SetUp]
    public void Setup()
    {
        _shippingSlipRepositoryMock = new Mock<IShippingSlipRepository>();
        _shippingSlipRepositoryMock.Setup(x => x.GenerateShippingSlip(It.IsAny<ShippingSlipRow>()))
            .Returns(Task.FromResult(Result.Ok()));
        _sut = new GenerateShippingSlipCommand(_shippingSlipRepositoryMock.Object);
    }

    private GenerateShippingSlipCommand _sut;
    private Mock<IShippingSlipRepository> _shippingSlipRepositoryMock;
}