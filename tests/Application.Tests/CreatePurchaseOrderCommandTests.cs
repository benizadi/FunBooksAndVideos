using Application.Commands;
using Contracts;
using DataAccess.Models;
using DataAccess.Repositories;
using FluentAssertions;
using FluentResults;
using Moq;

namespace Application.Tests
{
    public class CreatePurchaseOrderCommandTests
    {
        [Test]
        public async Task When_CalledWithCorrectParams_ShouldReturnExecutionResult()
        {
            var result = await _sut.Execute(new CreatePurchaseOrderCommandArgs(new PurchaseOrder()));

            result.IsSuccess.Should().Be(true);
        }
        
        [Test]
        public async Task When_CalledWithCorrectParams_ShouldExecuteAddPurchase()
        {
            await _sut.Execute(new CreatePurchaseOrderCommandArgs(new PurchaseOrder()));

            _purchaseRepositoryMock.Verify(mock => mock.AddPurchaseOrder(It.IsAny<PurchaseOrderRow>()), Times.Once());
        }
        
        [SetUp]
        public void Setup()
        {
            _purchaseRepositoryMock = new Mock<IPurchaseOrderRepository>();
            _purchaseRepositoryMock.Setup(x => x.AddPurchaseOrder(It.IsAny<PurchaseOrderRow>()))
                .Returns(Task.FromResult(Result.Ok()));
            _sut = new CreatePurchaseOrderCommand(_purchaseRepositoryMock.Object);
        }
        
        private CreatePurchaseOrderCommand _sut;
        private Mock<IPurchaseOrderRepository> _purchaseRepositoryMock;
    }
}